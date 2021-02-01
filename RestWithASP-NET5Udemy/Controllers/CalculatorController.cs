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

        [HttpGet("sub/{number1}/{number2}")]
        public ActionResult Sub(string number1, string number2)
        {
            if (IsNumeric(number1) && IsNumeric(number2))
            {
                var nSub = ConvertToDecimal(number1) - ConvertToDecimal(number2);
                return Ok(nSub.ToString());
            }
            return BadRequest("Valores inválidos");
        }

        [HttpGet("mul/{number1}/{number2}")]
        public ActionResult Mul(string number1, string number2)
        {
            if (IsNumeric(number1) && IsNumeric(number2))
            {
                var nMult = ConvertToDecimal(number1) * ConvertToDecimal(number2);
                return Ok(nMult.ToString());
            }
            return BadRequest("Valores inválidos");
        }

        [HttpGet("div/{number1}/{number2}")]
        public ActionResult Div(string number1, string number2)
        {
            if (IsNumeric(number1) && IsNumeric(number2))
            {
                var nDivisao = ConvertToDecimal(number1) / ConvertToDecimal(number2);
                return Ok(nDivisao.ToString());
            }
            return BadRequest("Valores inválidos");
        }

        [HttpGet("med/{number1}/{number2}")]
        public ActionResult Media(string number1, string number2)
        {
            if (IsNumeric(number1) && IsNumeric(number2))
            {
                var nMedia = (ConvertToDecimal(number1) + ConvertToDecimal(number2)) / 2;
                return Ok(nMedia.ToString());
            }
            return BadRequest("Valores inválidos");
        }

        [HttpGet("rzq/{number1}")]
        public ActionResult Rzq(string number1)
        {
            if (IsNumeric(number1))
            {
                double nValor = ConvertToDouble(number1);
                return Ok(Math.Sqrt(nValor));
            }
            return BadRequest("Valores inválidos");
        }

        private decimal ConvertToDecimal(string sNumber)
        {
            decimal nDecimalValue;

            if (decimal.TryParse(sNumber, out nDecimalValue))
            {
                return nDecimalValue;
            }

            return 0;
        }

        private double ConvertToDouble(string sNumber)
        {
            double nDoublelValue;

            if (double.TryParse(sNumber, out nDoublelValue))
            {
                return nDoublelValue;
            }

            return 0;
        }

        private bool IsNumeric(string sNumber)
        {
            double nNumber;

            bool bIsNumber = double.TryParse(sNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out nNumber);

            return bIsNumber;
        }
    }
}
