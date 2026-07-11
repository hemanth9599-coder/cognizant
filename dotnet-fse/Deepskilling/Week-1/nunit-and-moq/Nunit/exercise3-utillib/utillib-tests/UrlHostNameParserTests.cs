using System;
using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser parser = null!;

        [SetUp]
        public void Setup()
        {
            parser = new UrlHostNameParser();
        }

        [TearDown]
        public void Cleanup()
        {
            parser = null!;
        }

        [Test]
        public void ParseHostName_HttpUrl_ReturnsHostName()
        {
            string result = parser.ParseHostName("http://www.google.com/search");

            Assert.That(result, Is.EqualTo("www.google.com"));
        }

        [Test]
        public void ParseHostName_HttpsUrl_ReturnsHostName()
        {
            string result = parser.ParseHostName("https://github.com/OpenAI");

            Assert.That(result, Is.EqualTo("github.com"));
        }

        [Test]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                parser.ParseHostName("ftp://example.com"));

            Assert.That(ex!.Message,
                Is.EqualTo("Url is not in correct format"));
        }

        [Test]
        public void ParseHostName_InvalidUrl_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                parser.ParseHostName("abcd://sample.com"));

            Assert.That(ex!.Message,
                Is.EqualTo("Url is not in correct format"));
        }
    }
}