using System.Reflection;
using MediatR;
using MicroBanking.Application.Interfaces;
using MicroBanking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.Communication.CommandHandlers;
using Banking.Domain.Communication.Commands;
using Banking.Domain.Interfaces;
using MicroBanking.Domain.Core.Bus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Infa.Bus;

namespace MicroBanking.Infra.Bus;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection collection)
    {
        collection.AddTransient<IEventBus, RabbitMQBus>();
        
        collection.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandler>();


        collection.AddTransient<IAccountService, AccountService>();

        collection.AddTransient<IAccountRepository, AccountRepository>();

        collection.AddTransient<BankingDbContext>();

        collection.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });
        
        collection.AddDbContext<BankingDbContext>(options =>
        {
            options.UseSqlServer("Data source=.; Initial Catalog=MicroBanking;Integrated Security = SSPI;Trust Server Certificate=True");
        });
    }
}