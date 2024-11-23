using Banking.Data.Context;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Data.Repository;

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