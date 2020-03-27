﻿using Interfaces;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuesImpl
{
    public class RabbitMQImpl : IListenerQueue, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IBotFactory _factory;
        private IConsumeSchechuler _scheduler;
        private ICredentialSaver _context;

        public RabbitMQImpl(IBotFactory fac, IConsumeSchechuler scheduler, ICredentialSaver context)
        {
            _factory = fac;
            _scheduler = scheduler;
            _context = context;
        }

        public void StartListening()
        {
            _connection = CreateConnection();

            _channel = _connection.CreateModel();

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);

            _channel.QueueDeclare(queue: "messages",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            consumer.Received += async (model, ea) =>
            {
                Console.WriteLine("waiting for queue");
                var _body = ea.Body;
                var msg = Encoding.UTF8.GetString(_body);
                var message = JsonConvert.DeserializeObject<MessageWithoutUser>(msg);
                Service utilService = message.Service;
                IBot bot = _factory.GetBot(utilService);
                var user = GetUserNamePassword(message.UserId);
                var cookie = bot.Login(user.Username, user.Password, message.UserId);
                var cookieExist = _context.GetCookie(message.UserId, message.Service);

                if (cookieExist == null)
                {
                    _context.SaveSessionId(cookie);
                }
                var _result = bot.ExecuteLikes(message.MessageId, message.UserId, message.Likes, message.Time,cookie.SessionId);

                if (_result > 0)
                {
                    await _scheduler.StartSchedule(message.MessageId, _result, DateTime.MinValue, utilService);
                    Console.WriteLine($"{_result} likes left");
                }
                bot.ShutDown();

            };
            _channel.BasicConsume(queue: "messages",
                                       autoAck: true,
                                       consumer: consumer);
            Console.ReadLine();

        }

        //public void StartListening()
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    var connection = factory.CreateConnection();
        //    var channel = connection.CreateModel();

        //        //channel.QueueDeclare(queue: "messages",
        //        //                     durable: false,
        //        //                     exclusive: false,
        //        //                     autoDelete: false,
        //        //                     arguments: null);

        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (model, ea) =>
        //        {
        //            var body = ea.Body;
        //            var message = Encoding.UTF8.GetString(body);
        //            Console.WriteLine(" [x] Received {0}", message);
        //        };
        //        channel.BasicConsume(queue: "messages",
        //                             autoAck: true,
        //                             consumer: consumer);

        //        Console.WriteLine(" Press [enter] to exit.");
        //        Console.ReadLine();

        //}
        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            return factory.CreateConnection();
        }
        ~RabbitMQImpl()
        {
            Dispose();
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }

        public MessageWithoutUser DeserializeJsonMesage(byte[] msg)
        {
            var message = Encoding.UTF8.GetString(msg);
            return JsonConvert.DeserializeObject<MessageWithoutUser>(message);
        }

        public byte[] SerializeMessage(MessageWithoutUser msg)
        {
            var newJson = JsonConvert.SerializeObject(msg);
            return Encoding.UTF8.GetBytes(newJson);
        }

        public UsersCredentialsModel GetUserNamePassword(string id)
        {
            return _context.GetById(id);
        }
    }
}
