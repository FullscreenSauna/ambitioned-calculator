using AmbitionedCalculatorAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmbitionedCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorRepository calculatorRepository;

        public CalculatorController(ICalculatorRepository calculatorRepository)
        {
            this.calculatorRepository = calculatorRepository;
        }

        [HttpPost]
        public IActionResult Caclulate(string mathExpression)
        {
            if (!calculatorRepository.CheckMathExpressionValid(mathExpression))
            {
                return ValidationProblem();
            }

            var result = calculatorRepository.Calculate(mathExpression).ToString();

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
