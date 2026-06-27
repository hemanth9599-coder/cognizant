using System;

namespace AdapterPatternExample
{
    // Target Interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // Adaptee 1
    public class PayPalGateway
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Payment of Rs.{amount} processed using PayPal.");
        }
    }

    // Adaptee 2
    public class StripeGateway
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Payment of Rs.{amount} processed using Stripe.");
        }
    }

    // Adapter for PayPal
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway paypal;

        public PayPalAdapter(PayPalGateway paypal)
        {
            this.paypal = paypal;
        }

        public void ProcessPayment(double amount)
        {
            paypal.MakePayment(amount);
        }
    }

    // Adapter for Stripe
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeGateway stripe;

        public StripeAdapter(StripeGateway stripe)
        {
            this.stripe = stripe;
        }

        public void ProcessPayment(double amount)
        {
            stripe.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor payment1 = new PayPalAdapter(new PayPalGateway());
            payment1.ProcessPayment(2500);

            IPaymentProcessor payment2 = new StripeAdapter(new StripeGateway());
            payment2.ProcessPayment(5000);
        }
    }
}