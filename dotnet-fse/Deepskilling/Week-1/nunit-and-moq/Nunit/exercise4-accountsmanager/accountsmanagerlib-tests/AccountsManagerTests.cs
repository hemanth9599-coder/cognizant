using System;
using NUnit.Framework;
using AccountsManagerLib;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class AccountsManagerTests
    {
        private AccountsManager manager = null!;

        [SetUp]
        public void Setup()
        {
            manager = new AccountsManager();
        }

        [TearDown]
        public void Cleanup()
        {
            manager = null!;
        }

        [Test]
        public void ValidateUser_ValidUser11_ReturnsWelcomeMessage()
        {
            string result = manager.ValidateUser("user_11", "secret@user11");

            Assert.That(result, Is.EqualTo("Welcome user_11!!!"));
        }

        [Test]
        public void ValidateUser_ValidUser22_ReturnsWelcomeMessage()
        {
            string result = manager.ValidateUser("user_22", "secret@user22");

            Assert.That(result, Is.EqualTo("Welcome user_22!!!"));
        }

        [Test]
        public void ValidateUser_InvalidCredentials_ReturnsInvalidMessage()
        {
            string result = manager.ValidateUser("admin", "12345");

            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        [Test]
        public void ValidateUser_EmptyUserId_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                manager.ValidateUser("", "secret@user11"));

            Assert.That(ex!.Message,
                Is.EqualTo("Both user id and password are mandatory"));
        }

        [Test]
        public void ValidateUser_EmptyPassword_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                manager.ValidateUser("user_11", ""));

            Assert.That(ex!.Message,
                Is.EqualTo("Both user id and password are mandatory"));
        }
    }
}