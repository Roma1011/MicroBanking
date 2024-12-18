﻿using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Data.Context;

internal class BankingDbContext:DbContext
{
    public BankingDbContext() {}
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }
    
    public DbSet<Account> Accounts { get; set; }
}