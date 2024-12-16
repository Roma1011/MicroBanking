using Microsoft.AspNetCore.Mvc;
using Transfer.Application.Interfaces;

namespace Transfer.Api.Controllers;

[ApiController]
[Route("TransferController")]
public class TransferController:ControllerBase
{
    private readonly ITransferService _transferService;
    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpGet(nameof(GetTransferLogs))]
    public async Task<IActionResult> GetTransferLogs()
    {
       return Ok(await _transferService.GetAccounts());
    }
    
}