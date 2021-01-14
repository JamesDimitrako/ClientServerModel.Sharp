using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ParallelEstimationOfPi;

namespace Grpc.Server
{
    public class EstimationOfPiService : EstimationOfPi.EstimationOfPiBase
    {
        private readonly ILogger<EstimationOfPiService> _logger;
        private static readonly int NumberOfCores = Environment.ProcessorCount;

        public EstimationOfPiService(ILogger<EstimationOfPiService> logger)
        {
            _logger = logger;
        }

        public override Task<PiReply> Estimate(PiRequest request, ServerCallContext context)
        {
            var parallelPiEstimation = new ParallelForEstimationOfPi(NumberOfCores);
            return Task.FromResult(new PiReply
            {
                Estimation = parallelPiEstimation.ParallelPi(request.NumberOfSteps)
            });
        }
    }
}