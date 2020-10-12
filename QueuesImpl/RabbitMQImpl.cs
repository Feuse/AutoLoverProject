using Interfaces;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueuesImpl
{
    public class RabbitMQImpl : IListenerQueue, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IBotFactory _factory;
        private IConsumeSchechuler _scheduler;
        private ICredentialDb _context;

        public RabbitMQImpl(IBotFactory fac, IConsumeSchechuler scheduler, ICredentialDb context)
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
            int result = 0;
            consumer.Received += async (model, ea) =>
            {

                Console.WriteLine("waiting for queue");
                var _body = ea.Body;
                var msg = Encoding.UTF8.GetString(_body);
                var message = JsonConvert.DeserializeObject<MessageWithoutUser>(msg);
                Service service = message.Service;
                IBot bot = _factory.GetBot(service);

                var user = await GetUserNamePassword(message.UserId);

                await bot.InitializeBot(user, message);

                result = await bot.ExecuteLikes(message);
                _channel.BasicAck(ea.DeliveryTag, false);
                if (result > 0)
                {
                    await _scheduler.StartSchedule(message.MessageId, result, service, message.UserId);
                }
            };
            _channel.BasicConsume(queue: "messages",
                                                  autoAck: false,
                                                 consumer: consumer);

            Console.ReadLine();

        }
      
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

        public async Task<ServiceCredentialsModel> GetUserNamePassword(string id)
        {
            return  await _context.GetByIdServiceCredentialsModel(id);

        }
    }
}
