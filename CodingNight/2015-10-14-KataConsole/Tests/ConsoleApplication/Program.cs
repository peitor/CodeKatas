namespace ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            var ui = new UI(new RealConsoleAdapter());
            while (ui.Process())
            {
            }
        }
    }
}
