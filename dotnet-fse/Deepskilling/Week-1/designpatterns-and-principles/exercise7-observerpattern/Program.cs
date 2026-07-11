using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    // Observer Interface
    public interface IObserver
    {
        void Update(string stockName, double price);
    }

    // Subject Interface
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void NotifyObservers();
    }

    // Concrete Subject
    public class StockMarket : IStock
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        private string stockName;
        private double stockPrice;

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void SetStock(string name, double price)
        {
            stockName = name;
            stockPrice = price;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(stockName, stockPrice);
            }
        }
    }

    // Concrete Observer - Mobile App
    public class MobileApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine($"Mobile App: {stockName} price updated to Rs.{price}");
        }
    }

    // Concrete Observer - Web App
    public class WebApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine($"Web App: {stockName} price updated to Rs.{price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StockMarket stockMarket = new StockMarket();

            IObserver mobile = new MobileApp();
            IObserver web = new WebApp();

            stockMarket.RegisterObserver(mobile);
            stockMarket.RegisterObserver(web);

            Console.WriteLine("Stock Price Changed:");

            stockMarket.SetStock("TCS", 3850.75);
        }
    }
}