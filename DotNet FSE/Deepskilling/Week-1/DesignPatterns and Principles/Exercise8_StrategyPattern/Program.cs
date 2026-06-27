using System;

namespace StrategyPatternExample
{
    // Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // Concrete Strategy - Credit Card
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid Rs.{amount} using Credit Card.");
        }
    }

    // Concrete Strategy - PayPal
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid Rs.{amount} using PayPal.");
        }
    }

    // Context Class
    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(double amount)
        {
            paymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext(new CreditCardPayment());

            Console.WriteLine("Credit Card Payment:");
            context.ExecutePayment(2500);

            Console.WriteLine();

            context.SetPaymentStrategy(new PayPalPayment());

            Console.WriteLine("PayPal Payment:");
            context.ExecutePayment(3500);
        }
    }
}