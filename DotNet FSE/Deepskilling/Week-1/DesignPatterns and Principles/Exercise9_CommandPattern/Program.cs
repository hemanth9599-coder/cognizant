using System;

namespace CommandPatternExample
{
    // Command Interface
    public interface ICommand
    {
        void Execute();
    }

    // Receiver
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    // Concrete Command - Turn On
    public class LightOnCommand : ICommand
    {
        private readonly Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    // Concrete Command - Turn Off
    public class LightOffCommand : ICommand
    {
        private readonly Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }

    // Invoker
    public class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);

            RemoteControl remote = new RemoteControl();

            Console.WriteLine("Turning Light ON:");
            remote.SetCommand(lightOn);
            remote.PressButton();

            Console.WriteLine();

            Console.WriteLine("Turning Light OFF:");
            remote.SetCommand(lightOff);
            remote.PressButton();
        }
    }
}