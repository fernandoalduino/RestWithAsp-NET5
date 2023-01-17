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
            if (firstNumber == null || secondNumber == null)
                return NotFound();

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                return NotFound();

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sub = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult Mul(string firstNumber, string secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                return NotFound();

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var mul = convertToDecimal(firstNumber) * convertToDecimal(secondNumber);
                return Ok(mul.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                return NotFound();

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var div = convertToDecimal(firstNumber) / convertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult Square(string firstNumber)
        {
            if (firstNumber == null)
                return NotFound();

            if (isNumeric(firstNumber))
            {
                var square = convertToDecimal(firstNumber);
                if(square > 0)
                {
                    decimal root = square / 3;
                    for(int i = 0; i < 32; i++)
                        root = (root + square / root) / 2;
                    return Ok(root.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("pow/{firstNumber}/{secondNumber}")]
        public IActionResult Pow(string firstNumber, string secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                return NotFound();

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var pow = convertToDecimal(secondNumber);
                decimal result = 1;

                if (pow > 0)
                {
                    for (int i = 1; i <= pow; ++i)
                    {
                        result *= convertToDecimal(firstNumber);
                    }
                }
                else if (pow < 0)
                {
                    for (int i = -1; i >= pow; --i)
                    {
                        result /= convertToDecimal(firstNumber);
                    }
                }
                return Ok(result.ToString());
            }

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