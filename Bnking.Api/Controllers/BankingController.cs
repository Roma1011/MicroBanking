using MicroBanking.Application.DTO;
using MicroBanking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bnking.Api.Controllers;

[ApiController]
[Route("BankingController")]
public class BankingController(IAccountService accountService):ControllerBase
{
    [HttpGet(nameof(GetAccounts))]
    public async Task<IActionResult> GetAccounts()
        => Ok(await accountService.GetAccounts());
    
    [HttpPost(nameof(PostAccTransfer))]
    public async Task<IActionResult> PostAccTransfer([FromBody]AccountTransfer accTransfer)
        => Ok(accountService.AccTransfer(accTransfer));
    
}