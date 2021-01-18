using System;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static async Task  Main(string[] args)
        {

            Console.WriteLine("Hello World from client!");
            
            Console.WriteLine(@"Please choose between options: 1: GRPC 2: ");
            // Takes the option for implementation
            var inputChoice = Console.ReadLine();
            bool validInput = Int32.TryParse(inputChoice, out var choiceOfInput);
            if (!validInput)
                throw new ArgumentException("Not a valid number;");

            Console.WriteLine(@"Please choose between options: 1: GRPC 2: Sockets 3: MessageQueue 4: WebService(HTTP) ");
            // Takes Number of steps
            var inputNumberOfSteps = Console.ReadLine();
            bool validNumberOfSteps = Int64.TryParse(inputNumberOfSteps, out var numberOfSteps);
            if (!validNumberOfSteps)
                throw new ArgumentException("Not a valid number for number of steps;");



            //SocketSynchronousClient.StartClient();

            switch (choiceOfInput)
            {
                // Grpc Client
                case 1:
                    await GrpcClient.EstimatePi(numberOfSteps);
                    break;
                // Sockets Client
                case 2:
                    SocketClient.StartClient(numberOfSteps);
                    break;
                // Message Queue(Rabbit MQ)
                case 3:
                    var messageQueue = new MessageQueueClient();
                    messageQueue.SendMessageToQueue("40000");
                    break;
                // Http Client
                case 4:
                    var httpClient = new HttpClientConsole();
                    var pi = httpClient.SendToPiEstimator(numberOfSteps);
                    Console.WriteLine(pi);
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }
        }
    }
}