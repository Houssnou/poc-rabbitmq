using POC.Core.Events;

namespace POC.Banking.Core.Events;

public class TransferCreatedEvent : Event
{
    public int From { get; private set; }
    public int To { get; private set; }
    public decimal Amount { get; private set; }

    public TransferCreatedEvent(int from, int to, decimal amt)
    {
        From = from;
        To = to;
        Amount = amt;
    }
}