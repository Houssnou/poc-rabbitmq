using POC.Core.Events;
using System.Text.Json.Serialization;

namespace POC.Transfer.Core.Events;

public class TransferCreatedEvent : Event
{
    public int From { get; set; }
    public int To { get; set; }
    public decimal Amount { get; set; }

    public TransferCreatedEvent()
    {
    }
    public TransferCreatedEvent(int from, int to, decimal amt)
    {
        From = from;
        To = to;
        Amount = amt;
    }
}