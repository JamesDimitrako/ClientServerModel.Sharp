﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ParallelEstimationOfPi;
using WebServiceApi.Server.Models;

namespace WebServiceApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiController : Controller
    {
        [HttpGet("{numberOfSteps}")]
        public async Task<IActionResult> Get(long numberOfSteps)
        { 
             int numberOfCores = Environment.ProcessorCount;

             var piEstimation = new ParallelForEstimationOfPi(numberOfCores);


            // Creates a new model of Pi /Models/Pi(For Json serialization)
            var pi = new PiEstimation
            {
                MyPi = await piEstimation.ParallelPi(numberOfSteps)
            };

            //jsonReturn.
            return Ok(pi);
        }
    }
}
