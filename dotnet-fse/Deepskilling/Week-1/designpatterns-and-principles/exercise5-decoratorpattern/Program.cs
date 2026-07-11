using System;

namespace DecoratorPatternExample
{
    // Component Interface
    public interface INotifier
    {
        void Send(string message);
    }

    // Concrete Component
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Notification: {message}");
        }
    }

    // Abstract Decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier notifier;

        public NotifierDecorator(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public virtual void Send(string message)
        {
            notifier.Send(message);
        }
    }

    // Concrete Decorator - SMS
    public class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"SMS Notification: {message}");
        }
    }

    // Concrete Decorator - Slack
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Slack Notification: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email Only");
            INotifier email = new EmailNotifier();
            email.Send("Server is running.");

            Console.WriteLine();

            Console.WriteLine("Email + SMS");
            INotifier emailSms = new SMSNotifierDecorator(new EmailNotifier());
            emailSms.Send("Server is running.");

            Console.WriteLine();

            Console.WriteLine("Email + SMS + Slack");
            INotifier allNotifications =
                new SlackNotifierDecorator(
                    new SMSNotifierDecorator(
                        new EmailNotifier()));

            allNotifications.Send("Server is running.");
        }
    }
}