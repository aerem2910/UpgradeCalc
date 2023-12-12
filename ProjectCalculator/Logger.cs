using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Logger
{
    private string logFilePath = "calculator_log.txt";

    public void LogOperation(string operation)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"{DateTime.Now}: {operation}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging operation: {ex.Message}");
        }
    }
}
