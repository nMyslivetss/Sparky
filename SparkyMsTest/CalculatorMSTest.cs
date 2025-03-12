using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyMsTest
{
    [TestClass]
    public class CalculatorMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectEdition()
        {
            // Arange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(5, 10);

            // Assert
            Assert.AreEqual(15, result);
        }


    }
}
