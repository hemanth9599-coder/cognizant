using Moq;
using NUnit.Framework;
using PlayerManagerLib;

namespace PlayerManagerLib.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> mockMapper = null!;
        private PlayerManager manager = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            mockMapper = new Mock<IPlayerMapper>();

            mockMapper
                .Setup(x => x.GetPlayerById(1))
                .Returns(new Player
                {
                    Id = 1,
                    Name = "Virat Kohli"
                });

            manager = new PlayerManager(mockMapper.Object);
        }

        [Test]
        public void GetPlayer_ShouldReturnPlayer()
        {
            Player player = manager.GetPlayer(1);

            Assert.That(player.Id, Is.EqualTo(1));
            Assert.That(player.Name, Is.EqualTo("Virat Kohli"));
        }
    }
}