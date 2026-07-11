using System;
using NUnit.Framework;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        private User user = null!;

        [SetUp]
        public void Setup()
        {
            user = new User();
        }

        [TearDown]
        public void Cleanup()
        {
            user = null!;
        }

        [Test]
        public void ValidatePANCardNumber_ValidPAN_ReturnsValid()
        {
            string result = user.ValidatePANCardNumber("ABCDE1234F");

            Assert.That(result, Is.EqualTo("Valid"));
        }

        [Test]
        public void ValidatePANCardNumber_NullPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
                user.ValidatePANCardNumber(null));

            Assert.That(ex!.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_EmptyPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
                user.ValidatePANCardNumber(""));

            Assert.That(ex!.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_InvalidLength_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                user.ValidatePANCardNumber("ABC123"));

            Assert.That(ex!.Message,
                Is.EqualTo("Pan Card Number Should contain only 10 characters"));
        }

        [Test]
        public void CreateUser_ValidPAN_DoesNotThrowException()
        {
            User newUser = new User
            {
                PANCardNo = "ABCDE1234F"
            };

            Assert.DoesNotThrow(() => newUser.CreateUser(newUser));
        }
    }
}