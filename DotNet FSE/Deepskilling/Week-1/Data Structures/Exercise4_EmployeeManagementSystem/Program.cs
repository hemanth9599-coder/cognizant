using System;

namespace EmployeeManagementSystem
{
    class Employee
    {
        public int EmployeeId;
        public string Name;
        public string Position;
        public double Salary;

        public Employee(int id, string name, string position, double salary)
        {
            EmployeeId = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    class Program
    {
        static Employee[] employees = new Employee[10];
        static int count = 0;

        static void AddEmployee(Employee employee)
        {
            if (count < employees.Length)
            {
                employees[count++] = employee;
                Console.WriteLine("Employee Added Successfully");
            }
            else
            {
                Console.WriteLine("Employee Array is Full");
            }
        }

        static void SearchEmployee(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    Console.WriteLine($"Employee Found: {employees[i].Name}");
                    return;
                }
            }

            Console.WriteLine("Employee Not Found");
        }

        static void TraverseEmployees()
        {
            Console.WriteLine("\nEmployee Details");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    $"ID: {employees[i].EmployeeId}, " +
                    $"Name: {employees[i].Name}, " +
                    $"Position: {employees[i].Position}, " +
                    $"Salary: Rs.{employees[i].Salary}");
            }
        }

        static void DeleteEmployee(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        employees[j] = employees[j + 1];
                    }

                    employees[count - 1] = null;
                    count--;

                    Console.WriteLine("Employee Deleted Successfully");
                    return;
                }
            }

            Console.WriteLine("Employee Not Found");
        }

        static void Main(string[] args)
        {
            AddEmployee(new Employee(101, "Hemanth", "Developer", 50000));
            AddEmployee(new Employee(102, "Rahul", "Tester", 40000));
            AddEmployee(new Employee(103, "Kiran", "Manager", 70000));

            TraverseEmployees();

            Console.WriteLine();

            SearchEmployee(102);

            Console.WriteLine();

            DeleteEmployee(102);

            TraverseEmployees();

            Console.WriteLine("\nTime Complexity");
            Console.WriteLine("Add Employee      : O(1)");
            Console.WriteLine("Search Employee   : O(n)");
            Console.WriteLine("Traverse Employee : O(n)");
            Console.WriteLine("Delete Employee   : O(n)");
        }
    }
}