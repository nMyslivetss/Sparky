using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;
        [SetUp]
        public void SetUp()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [TestCase(95, 90, "A")]
        [TestCase(85, 90, "B")]
        [TestCase(65, 90, "C")]
        [TestCase(95, 65, "B")]
        [TestCase(95, 55, "F")]
        [TestCase(65, 55, "F")]
        [TestCase(50, 90, "F")]
        public void GradeCalc_InputScore95Attendance90_GetAGrade(int score, int attPerc, string value)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attPerc;

            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
