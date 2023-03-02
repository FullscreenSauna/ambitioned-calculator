﻿using AmbitionedCalculatorAPI.Interfaces;
using NCalc;

namespace AmbitionedCalculatorAPI.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public object Calculate(string mathExpression)
        {
            var expression = new Expression(mathExpression);

            return expression.Evaluate();
        }


        public bool CheckMathExpressionValid (string mathExpression)
        {
            var expression = new Expression(mathExpression);

            if (expression.HasErrors())
            {
                return false;
            }

            return true;
        }
    }
}