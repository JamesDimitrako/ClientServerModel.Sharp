using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ParallelEstimationOfPi;

namespace Grpc.Server.Services
{
    public class EstimationOfPiService : EstimationOfPi.EstimationOfPiBase
    {
        private readonly ILogger<EstimationOfPiService> _logger;
        private static readonly int NumberOfCores = Environment.ProcessorCount;

        public EstimationOfPiService(ILogger<EstimationOfPiService> logger)
        {
            _logger = logger;
        }

        public override async Task<PiReply> Estimate(PiRequest request, ServerCallContext context)
        {
            var parallelPiEstimation = new ParallelForEstimationOfPi(NumberOfCores);
            var piEstimation = await parallelPiEstimation.ParallelPi(request.NumberOfSteps);
            return new PiReply()
            {
                Estimation = piEstimation
            };
        }
    }
}