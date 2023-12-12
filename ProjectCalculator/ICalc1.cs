
internal interface ICalc1
{
    event EventHandler<EventArgs> GotResult;

    void CancelLast();
    void Divide(double value);
    void Multiply(double value);
    void Subtract(double value);
    void Sum(double value);
}