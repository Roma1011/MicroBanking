using Microsoft.EntityFrameworkCore;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Data.Repository;

internal class TransferLogRepository:ITransferLogRepository
{
    private readonly TransferDbContext _dbContext;
    public TransferLogRepository(TransferDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _dbContext.TransferLogs.AsEnumerable();
    }
}