using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;


namespace ClientConsole
{
    public class GrpcClient
    {
        public static async Task ConnectToServer()
        {
            // The port number(5005) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5005");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest {Name = "GreeterClient"});
            Console.WriteLine($"Greeting: {reply.Message}");
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}