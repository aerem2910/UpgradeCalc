using System;

namespace ProjectCalculator
{
    internal class Program
    {
        static void Calculator_GotResult(object sender, EventArgs e)
        {
            Console.WriteLine($"Result: {((Calculator)sender).Result}");
        }

        static void Main(string[] args)
        {
            ICalc calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.WriteLine("Введите желаемую операцию (sum, subtract, multiply, divide, cancel, exit):");
                string operation = Console.ReadLine()?.ToLower();

                switch (operation)
                {
                    case "sum":
                        Console.WriteLine("Enter a number:");
                        if (int.TryParse(Console.ReadLine(), out int sumValue))
                            calc.Sum(sumValue);
                        else
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;

                    case "subtract":
                        Console.WriteLine("Enter a number:");
                        if (int.TryParse(Console.ReadLine(), out int subtractValue))
                            calc.Subtract(subtractValue);
                        else
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;

                    case "multiply":
                        Console.WriteLine("Enter a number:");
                        if (int.TryParse(Console.ReadLine(), out int multiplyValue))
                            calc.Multiply(multiplyValue);
                        else
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;

                    case "divide":
                        Console.WriteLine("Enter a number:");
                        if (int.TryParse(Console.ReadLine(), out int divideValue) && divideValue != 0)
                            calc.Divide(divideValue);
                        else
                            Console.WriteLine("Invalid input. Please enter a valid non-zero number.");
                        break;

                    case "cancel":
                        calc.CancelLast();
                        break;

                    case "exit":
                        exitRequested = true;
                        break;

                    default:
                        Console.WriteLine("Invalid operation. Please enter a valid operation.");
                        break;
                }
            }
        }
    }
}


