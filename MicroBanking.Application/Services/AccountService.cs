using MicroBanking.Application.Interfaces;
using MicroBanking.Domain.Interfaces;
using MicroBanking.Domain.Models;

namespace MicroBanking.Application.Services;

public class AccountService(IAccountRepository accountRepository):IAccountService
{
    public async Task<List<Account>> GetAccounts()
    {
        var acc=await accountRepository.GetAccounts();
        return acc;
    }
}