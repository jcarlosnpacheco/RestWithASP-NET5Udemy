using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {        

        [HttpGet("sum/{number1}/{number2}")]
        public ActionResult Sum(string number1, string number2)
        {
            if (IsNumeric(number1) && IsNumeric(number2))
            {
                var sum = ConvertToDecimal(number1) + ConvertToDecimal(number2);
                return Ok(sum.ToString());
            }
            return BadRequest("Valores inválidos");
        }

    }
}
