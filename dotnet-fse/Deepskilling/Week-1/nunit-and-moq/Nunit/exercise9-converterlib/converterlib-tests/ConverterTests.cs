using Moq;
using NUnit.Framework;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> mockFeed = null!;
        private Converter converter = null!;

        [SetUp]
        public void Setup()
        {
            mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();

            mockFeed
                .Setup(x => x.GetActualUSDollarValue())
                .Returns(0.85);

            converter = new Converter(mockFeed.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            converter = null!;
        }

        [Test]
        public void USDToEuro_100Dollar_Returns85Euro()
        {
            double result = converter.USDToEuro(100);

            Assert.That(result, Is.EqualTo(85));
        }

        [Test]
        public void USDToEuro_200Dollar_Returns170Euro()
        {
            double result = converter.USDToEuro(200);

            Assert.That(result, Is.EqualTo(170));
        }

        [Test]
        public void USDToEuro_ZeroDollar_ReturnsZero()
        {
            double result = converter.USDToEuro(0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void USDToEuro_VerifyExchangeRateCalledOnce()
        {
            converter.USDToEuro(100);

            mockFeed.Verify(x => x.GetActualUSDollarValue(), Times.Once);
        }
    }
}