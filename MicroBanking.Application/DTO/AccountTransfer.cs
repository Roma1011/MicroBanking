namespace MicroBanking.Application.DTO;

public class AccountTransfer
{
    public int FromAccount { get; set; }
    public int ToAccount { get; set; }
    public decimal TransferAmount { get; set; }
    
}