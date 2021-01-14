using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelEstimationOfPi
{
    public class ParallelForEstimationOfPi
    {
        private readonly int _numberOfCores;

        public ParallelForEstimationOfPi(int numberOfCores)
        {
            _numberOfCores = numberOfCores;
        }

        public  double ParallelPi(long numberOfSteps)
        {
            long count = 0;
            Parallel.For(0, _numberOfCores, new ParallelOptions{ MaxDegreeOfParallelism = _numberOfCores }, i =>
            {
                int localCounterInside = 0;
                Random random = new Random(); 

                for (int j = 0; j < numberOfSteps / _numberOfCores; ++j)
                {
                    double x = random.NextDouble();
                    double y = random.NextDouble();
                    double z = Math.Pow(x, 2) + Math.Pow(y, 2);
                    if (z <= 1.0) localCounterInside++;                                                                    }
                
                // Adds two 64-bit integers and replaces the first integer with the sum, as an atomic operation.
                Interlocked.Add(ref count, localCounterInside); 
            }); 

            double pi = 4 * (count / (double)numberOfSteps);

            return pi;
        }
    }
}