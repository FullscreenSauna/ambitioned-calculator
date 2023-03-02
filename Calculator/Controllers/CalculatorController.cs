﻿using Calculator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorRepository calculatorRepository;

        public CalculatorController(ICalculatorRepository calculatorRepository)
        {
            this.calculatorRepository = calculatorRepository;
        }

        [HttpPost]
        public IActionResult Caclulate([FromBody]string mathExpression)
        {
            if (string.IsNullOrEmpty(mathExpression) ||
                !calculatorRepository.CheckMathExpressionValid(mathExpression))
            {
                return ValidationProblem("Invalid mathematical equation");
            }

            var result = calculatorRepository.Calculate(mathExpression).ToString();

            if (string.IsNullOrEmpty(result))
            {
                return Json(StatusCode(500, "Something went wrong!"));
            }

            return Ok(result);
        }
    }
}
