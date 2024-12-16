using MicroBanking.Domain.Core.Bus;
using Transfer.Application.Interfaces;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Application.Services;

internal class TransferService:ITransferService
{
    private readonly ITransferLogRepository _transferLogRepository;
    private readonly IEventBus _bus;
    public TransferService(ITransferLogRepository transferLogRepository, IEventBus bus)
    {
        _transferLogRepository = transferLogRepository;
        _bus = bus;
    }

    public async Task<IEnumerable<TransferLog?>> GetAccounts()
    {
        return await Task.FromResult(_transferLogRepository.GetTransferLogs());
    }
}