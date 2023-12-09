using System;

namespace ProjectCalculator
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;

        void Sum(int value);
        void Subtract(int value);
        void Multiply(int value);
        void Divide(int value);
        void CancelLast();
    }
}
