using System.Reflection;
using MediatR;
using MicroBanking.Application.Interfaces;
using MicroBanking.Application.Services;
using MicroBanking.Data.Context;
using MicroBanking.Data.Repository;
using MicroBanking.Domain.Communication.CommandHandlers;
using MicroBanking.Domain.Communication.Commands;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Domain.Interfaces;
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