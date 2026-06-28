using System;

namespace ECommerceSearch
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public string Category;

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }
    }

    class Program
    {
        // Linear Search
        static int LinearSearch(Product[] products, string name)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        // Binary Search
        static int BinarySearch(Product[] products, string name)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int compare = string.Compare(products[mid].ProductName, name, true);

                if (compare == 0)
                    return mid;
                else if (compare < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101,"Keyboard","Electronics"),
                new Product(102,"Laptop","Electronics"),
                new Product(103,"Mobile","Electronics"),
                new Product(104,"Mouse","Electronics"),
                new Product(105,"Speaker","Electronics")
            };

            Console.WriteLine("Linear Search:");

            int linearIndex = LinearSearch(products, "Mouse");

            if (linearIndex != -1)
                Console.WriteLine($"Product Found: {products[linearIndex].ProductName}");
            else
                Console.WriteLine("Product Not Found");

            Console.WriteLine();

            Console.WriteLine("Binary Search:");

            int binaryIndex = BinarySearch(products, "Mouse");

            if (binaryIndex != -1)
                Console.WriteLine($"Product Found: {products[binaryIndex].ProductName}");
            else
                Console.WriteLine("Product Not Found");

            Console.WriteLine();
            Console.WriteLine("Time Complexity");
            Console.WriteLine("Linear Search");
            Console.WriteLine("Best Case    : O(1)");
            Console.WriteLine("Average Case : O(n)");
            Console.WriteLine("Worst Case   : O(n)");

            Console.WriteLine();

            Console.WriteLine("Binary Search");
            Console.WriteLine("Best Case    : O(1)");
            Console.WriteLine("Average Case : O(log n)");
            Console.WriteLine("Worst Case   : O(log n)");
        }
    }
}