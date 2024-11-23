using MicroBanking.Application.DTO;
using MicroBanking.Application.Interfaces;
using Banking.Domain.Communication.Commands;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using MicroBanking.Domain.Core.Bus;

namespace MicroBanking.Application.Services;

public class AccountService(IEventBus eventBus,IAccountRepository accountRepository):IAccountService
{
    public async Task<List<Account>> GetAccounts()
    {
        var acc=await accountRepository.GetAccounts();
        return acc;
    }

    public Task AccTransfer(AccountTransfer accountTransfer)
    {
        var createTransferCommand = new CreateTransferCommand
        (
            accountTransfer.FromAccount,
            accountTransfer.ToAccount,
            accountTransfer.TransferAmount
        );
        eventBus.SendCommand(createTransferCommand);
        return Task.CompletedTask;
    }
}