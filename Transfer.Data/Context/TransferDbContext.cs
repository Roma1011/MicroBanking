using Microsoft.EntityFrameworkCore;

namespace Transfer.Data.Context;

public class TransferDbContext:DbContext
{
    public TransferDbContext() { }
    public TransferDbContext(DbContextOptions<TransferDbContext> optionsBuilder):base(optionsBuilder) { }
    public DbSet<Domain.Models.TransferLog> TransferLogs { get; set; }
}