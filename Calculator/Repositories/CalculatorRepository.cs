using Calculator.Interfaces;
using NCalc;
using System.Text.RegularExpressions;

namespace Calculator.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public object Calculate(string mathExpression)
        {
            var expression = new Expression(mathExpression);

            return expression.Evaluate();
        }

        public bool CheckMathExpressionValid(string mathExpression)
        {
            var allowedSymbols = new Regex(@"^[0-9\+\-\*\/\(\).\s]+$");

            if (!allowedSymbols.IsMatch(mathExpression))
            {
                return false;
            }

            var expression = new Expression(mathExpression);

            if (expression.HasErrors())
            {
                return false;
            }

            return true;
        }
    }
}
