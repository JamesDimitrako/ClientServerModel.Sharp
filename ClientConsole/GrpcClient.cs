using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;


namespace ClientConsole
{
    public class GrpcClient
    {
        public static async Task EstimatePi(long numberOfSteps)
        {
            


            // The port number(5005) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5005");

            var piClient = new EstimationOfPi.EstimationOfPiClient(channel);

            var replyPi = await piClient.EstimateAsync(new PiRequest {NumberOfSteps = numberOfSteps });

            Console.WriteLine($"myPi Grpc: {replyPi}");
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}