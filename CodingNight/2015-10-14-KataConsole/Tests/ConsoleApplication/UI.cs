namespace ConsoleApplication
{
    using System;

    public class UI
    {
        private readonly IConsoleAdapter consoleAdapter;

        private State currentState = State.Initial;

        public UI(IConsoleAdapter consoleAdapter)
        {
            this.consoleAdapter = consoleAdapter;
        }

        public bool Process()
        {
            if (currentState == State.Initial)
            {
                this.consoleAdapter.Write("Shape: (C)ircle or (R)ectangle?");
                currentState = State.ReadShape;
                return true;
            }
            var read = this.consoleAdapter.Read();

            if (read == "R")
            {
                currentState = State.ReadRectangleSideA;
                this.consoleAdapter.Write("Rectangle side A length?");
                return true;
            }
            if (read == "C")
            {
                currentState = State.ReadCircleRadius;
                this.consoleAdapter.Write("Circle radius?");
                return true;
            }

            if (currentState == State.ReadCircleRadius)
            {
                this.consoleAdapter.Write($"{Math.PI}");
                return true;
            }
            if (currentState == State.ReadRectangleSideA)
            {
                consoleAdapter.Write("Rectangle side B length?");
                currentState = State.ReadRectangleSideB;
                return true;
            }
            if (currentState == State.ReadRectangleSideB)
            {
                consoleAdapter.Write("1");
                return true;
            }

            return true;
        }
    }

    internal enum State
    {
        Initial,

        ReadShape,

        ReadRectangleSideA,

        ReadCircleRadius,

        ReadRectangleSideB
    }

    public class ConsoleAdapter : IConsoleAdapter
    {
        public void Write(string message)
        {
            this.CurrentLine = message;
        }

        public string Read()
        {
            if (this.UserInput == null) throw new InvalidOperationException();
            var userInput = this.UserInput;
            this.UserInput = null;
            return userInput;
        }

        public string CurrentLine { get; set; }

        public string UserInput { get; set; }
    }

    public interface IConsoleAdapter
    {
        void Write(string message);

        string Read();
    }

    class RealConsoleAdapter : IConsoleAdapter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}