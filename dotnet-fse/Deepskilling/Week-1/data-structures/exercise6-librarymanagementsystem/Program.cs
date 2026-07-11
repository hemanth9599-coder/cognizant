using System;

namespace LibraryManagementSystem
{
    class Book
    {
        public int BookId;
        public string Title;
        public string Author;

        public Book(int id, string title, string author)
        {
            BookId = id;
            Title = title;
            Author = author;
        }
    }

    class Program
    {
        // Linear Search
        static int LinearSearch(Book[] books, string title)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            return -1;
        }

        // Binary Search
        static int BinarySearch(Book[] books, string title)
        {
            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int result = string.Compare(books[mid].Title, title, true);

                if (result == 0)
                    return mid;

                if (result < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Book[] books =
            {
                new Book(101, "C Programming", "Dennis Ritchie"),
                new Book(102, "Data Structures", "Mark Allen"),
                new Book(103, "Java", "James Gosling"),
                new Book(104, "Python", "Guido Van Rossum"),
                new Book(105, "SQL", "Donald Chamberlin")
            };

            Console.WriteLine("Linear Search");

            int linear = LinearSearch(books, "Python");

            if (linear != -1)
                Console.WriteLine($"Book Found : {books[linear].Title}");
            else
                Console.WriteLine("Book Not Found");

            Console.WriteLine();

            Console.WriteLine("Binary Search");

            int binary = BinarySearch(books, "Python");

            if (binary != -1)
                Console.WriteLine($"Book Found : {books[binary].Title}");
            else
                Console.WriteLine("Book Not Found");

            Console.WriteLine();
            Console.WriteLine("Time Complexity");
            Console.WriteLine("Linear Search : O(n)");
            Console.WriteLine("Binary Search : O(log n)");
        }
    }
}

