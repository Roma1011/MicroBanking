using Banking.Domain.Models;

namespace Banking.Domain.Interfaces;

public interface IAccountRepository
{
    public Task<List<Account>> GetAccounts();
}