using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RabbitMQ.Client;


namespace WebServiceApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageQueueController : Controller
    {
        [HttpGet("{numberOfSteps}")]
        public async Task<IActionResult> Get(long numberOfSteps)
        {

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 15672 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "estimatePi",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                
                var body = Encoding.UTF8.GetBytes(numberOfSteps.ToString());

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(" [x] NumberOfSteps {0}", numberOfSteps);
            }

            //jsonReturn.
            return Ok(numberOfSteps);
        }
    }
}
