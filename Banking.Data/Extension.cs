using System.Runtime.CompilerServices;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Banking.Application")]
namespace Banking.Data;

internal static class Extension
{
    public static IServiceCollection AddDataContext(this IServiceCollection collection)
    {
        collection.AddDbContext<BankingDbContext>(options =>
        {
            options.UseSqlServer("Data source=.; Initial Catalog=MicroBanking;Integrated Security = SSPI;Trust Server Certificate=True");
        });
        collection.AddTransient<IAccountRepository, AccountRepository>();
        return collection;
    }
}