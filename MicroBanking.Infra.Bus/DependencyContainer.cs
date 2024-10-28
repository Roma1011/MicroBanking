using MicroBanking.Application.Interfaces;
using MicroBanking.Application.Services;
using MicroBanking.Data.Context;
using MicroBanking.Data.Repository;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Infa.Bus;

namespace MicroBanking.Infra.Bus;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection collection)
    {
        collection.AddTransient<IEventBus, RabbitMQBus>();

        collection.AddTransient<IAccountService, AccountService>();

        collection.AddTransient<IAccountRepository, AccountRepository>();

        collection.AddTransient<BankingDbContext>();
    }
}