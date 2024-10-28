using MicroBanking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroBanking.Data.Context;

public class BankingDbContext:DbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> optionsBuilder):base(optionsBuilder) { }
    
    public DbSet<Account> Accounts { get; set; }
    
}