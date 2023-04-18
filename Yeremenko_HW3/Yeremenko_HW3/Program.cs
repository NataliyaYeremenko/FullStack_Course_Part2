namespace Yeremenko_HW3
{
    internal class Program
    {
        static void PrintGreen(string message)
        {
            var curColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = curColor;
        }
        static void PrintOrange(string message)
        {
            var curColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = curColor;
        }

        public delegate void PrintString(string message);

        static void Main(string[] args)
        {
            PrintString printString;
            Console.Write("Input string for print: ");
            string message = Console.ReadLine();
            Console.WriteLine();
            int colorNum=0;
            do {
                try
                {

                    Console.Write("Chose the print color:\n" +
                        "\t 1 - green;\n" +
                        "\t 2 - orange;\n" +
                        "\t 3 - both colors;\n" +
                        "\t 0 - exit;\n" +
                        "Your decision: ");
                    colorNum = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    switch (colorNum)
                    {
                        case 1: printString = PrintGreen; printString(message); break;
                        case 2: printString = PrintOrange; printString(message); break;
                        case 3: printString = PrintGreen; printString += PrintOrange; printString(message); break;
                        default: Console.WriteLine("Incorrect decision\n"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } 
            }
            while (colorNum != 0);
        }
    }
}