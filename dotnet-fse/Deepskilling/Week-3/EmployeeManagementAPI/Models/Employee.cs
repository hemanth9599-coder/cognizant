using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Salary { get; set; }

        public bool Permanent { get; set; }

        public Department? Department { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public DateTime DateOfBirth { get; set; }
    }
}