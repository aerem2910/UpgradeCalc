using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Program
{
    static void Calculator_GotResult(object sendler, EventArgs evenArgs)
    {
        Console.WriteLine($"{((Calculator)sendler).Result}");
    }

    static void Main(string[] args)
    {
        Logger logger = new Logger();
        ICalc calc = new Calculator(logger);
        calc.GotResult += Calculator_GotResult;

        try
        {

            calc.Sum(5);
            calc.Subtract(18);
            calc.Multiply(2);
            calc.Divide(0);  
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);
        }
    }
}

