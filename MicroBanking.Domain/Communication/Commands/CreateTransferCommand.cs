namespace MicroBanking.Domain.Communication.Commands;

public class CreateTransferCommand:TransferCommand
{
    public CreateTransferCommand(int from, int to, decimal amount)
    {
        base.From = from;
        base.To = to;
        base.Amount = amount;
    }
}