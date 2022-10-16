namespace POC.Banking.Core.Commands;

public class NewTransferCommand : TransferCommand
{
    public NewTransferCommand(int from, int to, decimal amt)
    {
        From = from;
        To = to;
        Amount = amt;
    }
}