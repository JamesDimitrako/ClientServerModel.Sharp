using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class HttpClientConsole
    {
        public async Task<double> SendToPiEstimator(long numberOfSteps)
        {
            double resultOfPi = 0;
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:5001/Pi/{numberOfSteps}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(result))
                    resultOfPi = Convert.ToDouble(result);
            }

            return resultOfPi;
        }
    }
}