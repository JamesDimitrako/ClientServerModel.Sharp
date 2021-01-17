using System;
using System.Text;
using RabbitMQ.Client;

namespace ClientConsole
{
    public class MessageQueueClient
    {
        public void SendMessageToQueue(string numberOfSteps)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                HostName = "localhost",
                ClientProvidedName = "app:audit component:event-consumer"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "estimatePi",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = numberOfSteps;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}