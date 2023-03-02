using Calculator.Interfaces;
using Calculator.Repositories;

namespace CalculatorTests
{
    internal class ExpressionValidationTests
    {
        private ICalculatorRepository calculatorRepository;

        [SetUp]
        public void Setup()
        {
            calculatorRepository = new CalculatorRepository();
        }

        #region PositiveTests
        [Test]
        public void ValidExpressionNoBracketsTest()
        {
            var expression = "22 + 2";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(result);
        }

        [Test]
        public void ValidExpressionWithBracketsTest()
        {
            var expression = "22 + 2 * (1 + 2)";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(result);
        }

        [Test]
        public void ValidExpressionDecimalsTest()
        {
            var expression = "1.5 + 1.5";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(result);
        }
        #endregion

        #region NegativeTests
        [Test]
        public void InValidExpressionNoBracketsTest()
        {
            var expression = "22 + 2 +";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }

        [Test]
        public void InValidExpressionWithOpenBracketsTest()
        {
            var expression = "22 + 2 * (1 + 2) + (";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }

        [Test]
        public void InValidExpressionWithClosedBracketsTest()
        {
            var expression = "22 + 2 * (1 + 2) + )";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }

        [Test]
        public void InValidExpressionDecimalsTest()
        {
            var expression = "1.5 + 1,5";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }

        [Test]
        public void InValidExpressionLetters()
        {
            var expression = "abc";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }

        [Test]
        public void InValidExpressionLettersAndNumbers()
        {
            var expression = "abc + 1";

            var result = calculatorRepository.CheckMathExpressionValid(expression);

            Assert.That(!result);
        }
        #endregion
    }
}
