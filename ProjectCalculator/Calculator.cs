using System;
using System.Collections.Generic;

namespace ProjectCalculator
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;

        public int Result = 0;
        private Stack<int> Results = new Stack<int>();

        public void Divide(int value)
        {
            Results.Push(Result);
            Result /= value;
            RaiseEvent();
        }

        public void Multiply(int value)
        {
            Results.Push(Result);
            Result *= value;
            RaiseEvent();
        }

        public void Subtract(int value)
        {
            Results.Push(Result);
            Result -= value;
            RaiseEvent();
        }

        public void Sum(int value)
        {
            Results.Push(Result);
            Result += value;
            RaiseEvent();
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RaiseEvent();
            }
            else
            {
                Console.WriteLine("No previous result to cancel.");
            }
        }

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }
}
