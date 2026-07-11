using System;

namespace ProxyPatternExample
{
    // Subject Interface
    public interface IImage
    {
        void Display();
    }

    // Real Subject
    public class RealImage : IImage
    {
        private readonly string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromServer();
        }

        private void LoadFromServer()
        {
            Console.WriteLine($"Loading {fileName} from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {fileName}");
        }
    }

    // Proxy Class
    public class ProxyImage : IImage
    {
        private readonly string fileName;
        private RealImage realImage;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            // Lazy Initialization
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }

            // Cached object is reused
            realImage.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("Nature.jpg");

            Console.WriteLine("First Display:");
            image.Display();

            Console.WriteLine();

            Console.WriteLine("Second Display:");
            image.Display();
        }
    }
}