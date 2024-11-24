using Transfer.Data.Context;
using Transfer.Domain.Interfaces;

namespace Transfer.Data.Repository;

internal class TransferLogRepository:ITransferLogRepository
{
    private readonly TransferDbContext _dbContext;
    public TransferLogRepository(TransferDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}