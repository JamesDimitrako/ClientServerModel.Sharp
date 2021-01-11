using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelEstimationOfPi
{
    public static class ParallelForEstimationOfPI
    {
        private static readonly int NumberOfCores = Environment.ProcessorCount;
        
        public static double ParallelPi(long numberOfSteps)
        {
            long count = 0;
            Parallel.For(0, NumberOfCores, new ParallelOptions{ MaxDegreeOfParallelism = NumberOfCores }, i =>
            {
                int localCounterInside = 0;
                Random random = new Random(); 

                for (int j = 0; j < numberOfSteps / NumberOfCores; ++j)
                {
                    double x = random.NextDouble();
                    double y = random.NextDouble();
                    double z = Math.Pow(x, 2) + Math.Pow(y, 2);
                    if (z <= 1.0) localCounterInside++;                                                      
                }
                
                // Adds two 64-bit integers and replaces the first integer with the sum, as an atomic operation.
                Interlocked.Add(ref count, localCounterInside); 
            }); 

            double pi = 4 * (count / (double)numberOfSteps);

            return pi;
        }
    }
}