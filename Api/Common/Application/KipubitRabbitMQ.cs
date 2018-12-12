using System;
using RabbitMQ.Client;
using System.Text;

namespace InkaPharmacy.Api.Common.Application
{
    public class KipubitRabbitMQ
    {
        public static void SendMessage(string message)
        {
            var factory = new ConnectionFactory();
            string rabbitmqUrl = Environment.GetEnvironmentVariable("KipubitMQ_URL");
            string queueName = Environment.GetEnvironmentVariable("inkapharmacyQueue");
            factory.Uri = new Uri(rabbitmqUrl);
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);           
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
        }
    }
}
