using System;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World from client!");
            //SocketSynchronousClient.StartClient();
            await GrpcClient.ConnectToServer();

        }
    }
}