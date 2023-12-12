using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;

    public double Result = 0;
    public Stack<Action> Actions = new Stack<Action>();
    public Logger logger;

    public Calculator(Logger logger)
    {
        this.logger = logger;
    }

    public void Divide(double value)
    {
        ExecuteOperation(() =>
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            Actions.Push(() => Result *= value);
            Result /= value;
        }, $"Divide by {value}");
    }

    public void Multiply(double value)
    {
        ExecuteOperation(() =>
        {
            Actions.Push(() => Result /= value);
            Result *= value;
        }, $"Multiply by {value}");
    }

    public void Subtract(double value)
    {
        ExecuteOperation(() =>
        {
            Actions.Push(() => Result += value);
            Result -= value;
        }, $"Subtract {value}");
    }

    public void Sum(double value)
    {
        ExecuteOperation(() =>
        {
            Actions.Push(() => Result -= value);
            Result += value;
        }, $"Sum {value}");
    }

    public void CancelLast()
    {
        if (Actions.Count > 0)
        {
            Actions.Pop().Invoke();
            RaiseEvent();
            logger.LogOperation("Cancel last operation");
        }
        else
        {
            Console.WriteLine("No previous operation to cancel.");
        }
    }

    private void ExecuteOperation(Action operation, string logMessage)
    {
        Actions.Clear();  
        operation.Invoke();
        RaiseEvent();
        logger.LogOperation(logMessage);
    }

    private void RaiseEvent()
    {
        GotResult?.Invoke(this, EventArgs.Empty);
    }
}
