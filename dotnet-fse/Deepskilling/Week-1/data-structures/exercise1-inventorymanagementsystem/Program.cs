using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, int quantity, double price)
        {
            ProductId = id;
            ProductName = name;
            Quantity = quantity;
            Price = price;
        }
    }

    class Inventory
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            products[product.ProductId] = product;
            Console.WriteLine($"Product '{product.ProductName}' added.");
        }

        public void UpdateProduct(int id, int quantity, double price)
        {
            if (products.ContainsKey(id))
            {
                products[id].Quantity = quantity;
                products[id].Price = price;
                Console.WriteLine($"Product ID {id} updated.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DeleteProduct(int id)
        {
            if (products.Remove(id))
                Console.WriteLine($"Product ID {id} deleted.");
            else
                Console.WriteLine("Product not found.");
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\nInventory Details");
            Console.WriteLine("-------------------------------");

            foreach (var product in products.Values)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, " +
                    $"Name: {product.ProductName}, " +
                    $"Quantity: {product.Quantity}, " +
                    $"Price: Rs.{product.Price}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.AddProduct(new Product(101, "Laptop", 10, 65000));
            inventory.AddProduct(new Product(102, "Mouse", 50, 500));
            inventory.AddProduct(new Product(103, "Keyboard", 20, 1200));

            inventory.DisplayProducts();

            inventory.UpdateProduct(102, 60, 550);

            inventory.DeleteProduct(103);

            inventory.DisplayProducts();

            Console.WriteLine("\nTime Complexity:");
            Console.WriteLine("Add Product    : O(1)");
            Console.WriteLine("Update Product : O(1)");
            Console.WriteLine("Delete Product : O(1)");
        }
    }
}