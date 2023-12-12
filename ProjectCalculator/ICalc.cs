using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICalc
{
    event EventHandler<EventArgs> GotResult;

    void Sum(double value);
    void Subtract(double value);
    void Multiply(double value);
    void Divide(double value);
    void CancelLast();
}
