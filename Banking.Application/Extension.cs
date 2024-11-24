using Banking.Data;
using MicroBanking.Application.Interfaces;
using MicroBanking.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBanking.Application;

public static class Extension
{
    public static IServiceCollection AddBankingServices(this IServiceCollection collection)
    {
        collection.AddTransient<IAccountService, AccountService>();
        collection.AddBankingDataContext();
        return collection;
    }
}