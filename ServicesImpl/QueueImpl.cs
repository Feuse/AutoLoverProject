using Interfaces;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesImpl
{
    public class QueueImpl : IQueue
    {
        public void Queue(MessageWithoutUser message)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };


            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "messages",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var body = SerializeJson(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "messages",
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
        public byte[] SerializeJson(MessageWithoutUser message)
        {
            var newMessage = JsonConvert.SerializeObject(message);
            var encoded = Encoding.UTF8.GetBytes(newMessage);
            return encoded;
        }
    }
}
