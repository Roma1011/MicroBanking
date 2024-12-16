using Transfer.Domain.Models;

namespace Transfer.Application.Interfaces;

public interface ITransferService
{
    public Task<IEnumerable<TransferLog?>> GetAccounts();
 //   public void Transfer(AccountTransfer accountTransfer);
}