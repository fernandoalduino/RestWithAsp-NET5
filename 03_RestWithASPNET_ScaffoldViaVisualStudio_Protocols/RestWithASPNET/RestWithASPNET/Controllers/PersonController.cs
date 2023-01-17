using Microsoft.AspNetCore.Mvc;
using System;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            return BadRequest("Invalid Input");
        }

        private decimal convertToDecimal(string number)
        {
            decimal decimalValue;
            if(decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string number)
        {
            double n;
            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out n);
            return isNumber;
        }
    }
}