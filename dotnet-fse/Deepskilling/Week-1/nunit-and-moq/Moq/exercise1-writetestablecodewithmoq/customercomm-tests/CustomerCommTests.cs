using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMailSender = null!;
        private CustomerCommunication customerComm = null!;

        [OneTimeSetUp]
        public void Init()
        {
            mockMailSender = new Mock<IMailSender>();

            mockMailSender
                .Setup(x => x.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(true);

            customerComm = new CustomerCommunication(mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ReturnsTrue()
        {
            bool result = customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);

            mockMailSender.Verify(
                x => x.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Once);
        }
    }
}