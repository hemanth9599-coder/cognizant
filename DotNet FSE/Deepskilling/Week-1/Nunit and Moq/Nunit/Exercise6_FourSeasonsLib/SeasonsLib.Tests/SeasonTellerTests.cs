using System.Collections;
using NUnit.Framework;
using SeasonsLib;

namespace SeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller seasonTeller = null!;

        [SetUp]
        public void Setup()
        {
            seasonTeller = new SeasonTeller();
        }

        [TearDown]
        public void Cleanup()
        {
            seasonTeller = null!;
        }

        public static IEnumerable SeasonData()
        {
            yield return new TestCaseData("February", "Spring");
            yield return new TestCaseData("March", "Spring");

            yield return new TestCaseData("April", "Summer");
            yield return new TestCaseData("May", "Summer");
            yield return new TestCaseData("June", "Summer");

            yield return new TestCaseData("July", "Monsoon");
            yield return new TestCaseData("August", "Monsoon");
            yield return new TestCaseData("September", "Monsoon");

            yield return new TestCaseData("October", "Autumn");
            yield return new TestCaseData("November", "Autumn");

            yield return new TestCaseData("December", "Winter");
            yield return new TestCaseData("January", "Winter");

            yield return new TestCaseData("ABC", "Invalid Season");
        }

        [Test]
        [TestCaseSource(nameof(SeasonData))]
        public void DisplaySeasonBy_ValidInput_ReturnsExpectedSeason(string month, string expected)
        {
            string actual = seasonTeller.DisplaySeasonBy(month);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}