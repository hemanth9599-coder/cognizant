using Moq;
using NUnit.Framework;
using DirectoryExplorerLib;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IFileSystem> mockFileSystem = null!;
    private DirectoryExplorerLib.DirectoryExplorer explorer = null!;
        [OneTimeSetUp]
        public void Setup()
        {
            mockFileSystem = new Mock<IFileSystem>();

            mockFileSystem
                .Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new string[]
                {
                    "A.txt",
                    "B.txt",
                    "Image.png",
                    "Movie.mp4"
                });

            explorer = new DirectoryExplorerLib.DirectoryExplorer(mockFileSystem.Object);
        }

        [Test]
        public void GetTextFiles_ShouldReturnOnlyTextFiles()
        {
            List<string> files = explorer.GetTextFiles("DummyPath");

            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files.Contains("A.txt"));
            Assert.That(files.Contains("B.txt"));
        }
    }
}