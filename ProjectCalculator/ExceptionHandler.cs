using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

internal class ExceptionHandler
{
    public static void HandleException(Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}
