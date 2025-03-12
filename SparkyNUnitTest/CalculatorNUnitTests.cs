using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectEdition()
        {
            // Act
            int result = _calculator.AddNumbers(5, 10);

            // Assert
            ClassicAssert.AreEqual(15, result);
        }

        [Test]
        public void IsOddNumbers_InputInt_GetTrue()
        {
            bool result = _calculator.IsOddNumber(4);

            ClassicAssert.IsTrue(result);
        }

        [TestCase(5, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = true)]
        public bool IsOddNumbers_InputInt_GetFalseOrTrue(int a)
        {
            return _calculator.IsOddNumber(a);
        }


        [TestCase(5.4, 10.5, 15.9)]   // 15.9
        [TestCase(5.43, 10.53, 15.96)] // 15.96
        [TestCase(5.49, 10.59, 16.08)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectEdition(double a, double b, double expected)
        {
            // Act
            double result = _calculator.AddNumbersDouble(a, b);

            // Assert
            ClassicAssert.AreEqual(expected, result, 0.01);
        }

        [Test]
        public void GetOddRange_InputMInAndMaxRange_ReturnsValidOddNUmberRange()
        {
            List<int> expectedOddRange = new() { 5, 7, 9};

            List<int> result = _calculator.GetOddRange(5, 10);

            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Does.Contain(9));
            Assert.That(result, Does.Not.Empty);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}
