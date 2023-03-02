using Calculator.Interfaces;
using Calculator.Repositories;

namespace CalculatorTests
{
    public class CalculationTests
    {
        private ICalculatorRepository calculatorRepository;

        [SetUp]
        public void Setup()
        {
            calculatorRepository = new CalculatorRepository();
        }

        #region PositiveTests
        [Test]
        public void AdditionPositiveTest()
        {
            var expectedResult = "2";

            var expression = "1 + 1";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void SubtractionPositiveTest()
        {
            var expectedResult = "0";

            var expression = "1 - 1";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void MuliplicationPositiveTest()
        {
            var expectedResult = "9";

            var expression = "3 * 3";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DivisionPositiveTest()
        {
            var expectedResult = "4";

            var expression = "16 / 4";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BracketsPositiveTest()
        {
            var expectedResult = "5.5";

            var expression = "1 + (3 * 3) / 2";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region NegativeTests
        [Test]
        public void AdditionNegativeTest()
        {
            var expectedResult = "2";

            var expression = "1 + 2";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, !Is.EqualTo(expectedResult));
        }

        [Test]
        public void SubtractionNegativeTest()
        {
            var expectedResult = "0";

            var expression = "1 - 2";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, !Is.EqualTo(expectedResult));
        }

        [Test]
        public void MuliplicationNegativeTest()
        {
            var expectedResult = "9";

            var expression = "3 * 1.1";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, !Is.EqualTo(expectedResult));
        }

        [Test]
        public void DivisionNegativeTest()
        {
            var expectedResult = "4";

            var expression = "16 / 12";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, !Is.EqualTo(expectedResult));
        }


        [Test]
        public void BracketsnNegativeTest()
        {
            var expectedResult = "5.5";

            var expression = "1 + (3 * 3) / 3";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, !Is.EqualTo(expectedResult));
        }
        #endregion

        #region SpecialTests
        [Test]
        public void DivideByZero()
        {
            var expectedResult = "∞";

            var expression = "1 / 0";
            var result = calculatorRepository.Calculate(expression).ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        #endregion
    }
}