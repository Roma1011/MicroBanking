using MicroBanking.Data.Context;
using MicroBanking.Domain.Interfaces;
using MicroBanking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroBanking.Data.Repository;

public class AccountRepository:IAccountRepository
{
    private BankingDbContext _ctx;

    public AccountRepository(BankingDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Account>> GetAccounts()
        => await _ctx.Accounts.ToListAsync();
}