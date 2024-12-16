using Transfer.Domain.Models;

namespace Transfer.Domain.Interfaces;

public interface ITransferLogRepository
{
    public  IEnumerable<TransferLog>GetTransferLogs();
}