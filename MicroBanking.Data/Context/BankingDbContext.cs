using MicroBanking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroBanking.Data.Context;

public class BankingDbContext:DbContext
{
    public BankingDbContext() {}
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }
    
    public DbSet<Account> Accounts { get; set; }
}