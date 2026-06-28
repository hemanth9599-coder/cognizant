using System;

namespace SortingCustomerOrders
{
    class Order
    {
        public int OrderId;
        public string CustomerName;
        public double TotalPrice;

        public Order(int id, string name, double price)
        {
            OrderId = id;
            CustomerName = name;
            TotalPrice = price;
        }
    }

    class Program
    {
        // Bubble Sort
        static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }
        }

        // Quick Sort
        static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(orders, low, high);

                QuickSort(orders, low, pi - 1);
                QuickSort(orders, pi + 1, high);
            }
        }

        static int Partition(Order[] orders, int low, int high)
        {
            double pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice < pivot)
                {
                    i++;

                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            Order t = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = t;

            return i + 1;
        }

        static void Display(Order[] orders)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine(
                    $"Order ID: {order.OrderId}, " +
                    $"Customer: {order.CustomerName}, " +
                    $"Price: Rs.{order.TotalPrice}");
            }
        }

        static void Main(string[] args)
        {
            Order[] orders =
            {
                new Order(101,"Hemanth",1200),
                new Order(102,"Rahul",6500),
                new Order(103,"Kiran",2500),
                new Order(104,"Ravi",5000)
            };

            Console.WriteLine("Bubble Sort");

            BubbleSort(orders);
            Display(orders);

            Console.WriteLine();

            Order[] orders2 =
            {
                new Order(101,"Hemanth",1200),
                new Order(102,"Rahul",6500),
                new Order(103,"Kiran",2500),
                new Order(104,"Ravi",5000)
            };

            Console.WriteLine("Quick Sort");

            QuickSort(orders2, 0, orders2.Length - 1);
            Display(orders2);

            Console.WriteLine();
            Console.WriteLine("Time Complexity");
            Console.WriteLine("Bubble Sort : O(n²)");
            Console.WriteLine("Quick Sort  : O(n log n)");
        }
    }
}