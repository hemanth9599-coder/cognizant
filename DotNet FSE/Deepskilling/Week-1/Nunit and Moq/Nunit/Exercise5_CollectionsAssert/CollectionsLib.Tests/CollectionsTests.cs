using System.Linq;
using NUnit.Framework;
using CollectionsLib;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class CollectionsTests
    {
        private EmployeeManager manager = null!;

        [SetUp]
        public void Setup()
        {
            manager = new EmployeeManager();
        }

        [TearDown]
        public void Cleanup()
        {
            manager = null!;
        }

        [Test]
        public void GetEmployees_AllItemsAreNotNull()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees, Is.All.Not.Null);
        }

        [Test]
        public void GetEmployees_ContainsEmployee100()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
        }

        [Test]
        public void GetEmployees_AllEmployeeIdsAreUnique()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees.Select(e => e.EmpId), Is.Unique);
        }

        [Test]
        public void PreviousYearEmployees_AreEqualToAllEmployees()
        {
            var allEmployees = manager.GetEmployees();
            var previousEmployees = manager.GetEmployeesWhoJoinedInPreviousYears();

            Assert.That(previousEmployees, Is.EqualTo(allEmployees));
        }
    }
}