using MicroBanking.Domain.Models;

namespace MicroBanking.Domain.Interfaces;

public interface IAccountRepository
{
    public Task<List<Account>> GetAccounts();
}