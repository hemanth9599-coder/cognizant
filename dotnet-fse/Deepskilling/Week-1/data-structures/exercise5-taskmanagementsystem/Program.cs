using System;

namespace TaskManagementSystem
{
    class Task
    {
        public int TaskId;
        public string TaskName;
        public string Status;
        public Task Next;

        public Task(int id, string name, string status)
        {
            TaskId = id;
            TaskName = name;
            Status = status;
            Next = null;
        }
    }

    class SinglyLinkedList
    {
        private Task head = null;

        public void AddTask(int id, string name, string status)
        {
            Task newTask = new Task(id, name, status);

            if (head == null)
            {
                head = newTask;
            }
            else
            {
                Task temp = head;

                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newTask;
            }

            Console.WriteLine("Task Added Successfully");
        }

        public void SearchTask(int id)
        {
            Task temp = head;

            while (temp != null)
            {
                if (temp.TaskId == id)
                {
                    Console.WriteLine($"Task Found: {temp.TaskName}");
                    return;
                }

                temp = temp.Next;
            }

            Console.WriteLine("Task Not Found");
        }

        public void TraverseTasks()
        {
            Console.WriteLine("\nTask List");

            Task temp = head;

            while (temp != null)
            {
                Console.WriteLine(
                    $"ID: {temp.TaskId}, " +
                    $"Task: {temp.TaskName}, " +
                    $"Status: {temp.Status}");

                temp = temp.Next;
            }
        }

        public void DeleteTask(int id)
        {
            if (head == null)
            {
                Console.WriteLine("Task Not Found");
                return;
            }

            if (head.TaskId == id)
            {
                head = head.Next;
                Console.WriteLine("Task Deleted Successfully");
                return;
            }

            Task current = head;

            while (current.Next != null && current.Next.TaskId != id)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                Console.WriteLine("Task Not Found");
            }
            else
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Task Deleted Successfully");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList tasks = new SinglyLinkedList();

            tasks.AddTask(101, "Design Database", "Pending");
            tasks.AddTask(102, "Develop API", "In Progress");
            tasks.AddTask(103, "Testing", "Pending");

            tasks.TraverseTasks();

            Console.WriteLine();

            tasks.SearchTask(102);

            Console.WriteLine();

            tasks.DeleteTask(102);

            tasks.TraverseTasks();

            Console.WriteLine("\nTime Complexity");
            Console.WriteLine("Add Task      : O(n)");
            Console.WriteLine("Search Task   : O(n)");
            Console.WriteLine("Traverse Task : O(n)");
            Console.WriteLine("Delete Task   : O(n)");
        }
    }
}