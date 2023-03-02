namespace AmbitionedCalculatorAPI.Interfaces
{
    public interface ICalculatorRepository
    {
        object Calculate(string mathExpression);

        bool CheckMathExpressionValid(string mathExpression);
    }
}