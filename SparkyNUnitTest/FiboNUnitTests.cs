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
    public class FiboNUnitTests
    {
        private Fibo _fibo;
        [SetUp]
        public void SetUp()
        {
            _fibo = new Fibo();
        }

        [Test]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() { 0 };
            _fibo.Range = 1;
            List<int> result = _fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(expectedRange));
            });
            
        }

        [Test]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            _fibo.Range = 6;
            List<int> result = _fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain(3));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result, Does.Not.Contain(4));
                Assert.That(result, Is.EquivalentTo(expectedRange));
            });

        }
    }
}
