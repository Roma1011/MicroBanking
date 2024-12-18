﻿using MicroBanking.Application.DTO;
using Banking.Domain.Models;

namespace MicroBanking.Application.Interfaces;

public interface IAccountService
{
    Task<List<Account>> GetAccounts();
    Task AccTransfer(AccountTransfer accountTransfer);
}