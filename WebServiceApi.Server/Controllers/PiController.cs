using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParallelEstimationOfPi;

namespace WebServiceApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiController : Controller
    {
        [HttpGet("{numberOfSteps}")]
        public async Task<IActionResult> Get(int numberOfSteps)
        { 
            int numberOfCores = Environment.ProcessorCount;
            var piEstimation = new ParallelForEstimationOfPi(numberOfCores);
            var pi = piEstimation.ParallelPi(numberOfSteps);
            return Ok(pi);
        }
    }
}
