using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [TestCase("Mikita", "Myslivets")]
        public void GreetAndCombineNames_InputFirstAndLastName_ReturnFullName(string name, string surname)
        {
            string fullName = customer.GreetAndCombineNames(name, surname);
            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo($"Hello, {name} {surname}"));
                Assert.That(fullName, Does.Contain("ll"));
                Assert.That(fullName, Does.Contain("mikita").IgnoreCase);
                Assert.That(fullName, Does.StartWith("H"));
                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            ClassicAssert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;

            Assert.That(result, Is.InRange(15, 19));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            var result = customer.GreetAndCombineNames("Ben", "");

            ClassicAssert.IsNotNull(customer.GreetMessage);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => 
                customer.GreetAndCombineNames("", "Spark"));

            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual("Empty First name", exceptionDetails.Message);
                Assert.That(() => customer.GreetAndCombineNames("", "Spark"),
                    Throws.ArgumentException.With.Message.EqualTo("Empty First name"));

                Assert.That(() => customer.GreetAndCombineNames("", "Sparky"), Throws.ArgumentException);
            });
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnsBasicCustomer()
        {
            customer.OrderTotal = 1001;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
