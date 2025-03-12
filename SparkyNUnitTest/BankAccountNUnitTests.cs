using Moq;
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
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;
        [SetUp]
        public void SetUp()
        {
        }

        //[Test]
        //public void BankDepositFakker_Add100_ReturnTrue()
        //{
        //    BankAccount _bankAccount = new(new LogFakker());
        //    var result = _bankAccount.Deposit(100);

        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        //        Assert.That(result, Is.EqualTo(true));
        //    });
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount _bankAccount = new(logMock.Object);
            var result = _bankAccount.Deposit(100);

            Assert.Multiple(() =>
            {
                Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
                Assert.That(result, Is.EqualTo(true));
            });
        }

        [TestCase(200, 100)]
        [TestCase(200, 200)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x >= 0))).Returns(true);

            BankAccount _bankAccount = new(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdrawal(withdraw);

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase(200, 300)]
        [TestCase(100, 500)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount _bankAccount = new(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdrawal(withdraw);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";
            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("Warning");

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Ben");

            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));
        }
    }
}
