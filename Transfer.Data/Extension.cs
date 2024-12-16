using System.Runtime.CompilerServices;
using MicroBanking.Domain.Core.Bus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.Communication.EventHandlers;
using Transfer.Domain.Communication.Events;
using Transfer.Domain.Interfaces;

[assembly:InternalsVisibleTo("Transfer.Application")]
[assembly:InternalsVisibleTo("Transfer.Api")]
namespace Transfer.Data;

internal static class Extension
{
    public static IServiceCollection AddTransferDataContext(this IServiceCollection collection)
    {
        collection.AddDbContext<TransferDbContext>(options =>
        {
            options.UseSqlServer("Data source=.; Initial Catalog=MicroTransferDb;Integrated Security = SSPI;Trust Server Certificate=True");
        });
        collection.AddTransient<ITransferLogRepository, TransferLogRepository>();
        return collection;
    }

    public static IApplicationBuilder ConfigureTransferBus(this IApplicationBuilder app)
    {
        var eventBus=app.ApplicationServices.GetRequiredService<IEventBus>();
        eventBus.Subscribe<TransferCreatedEvent,TransferEventHandler>();
        return app;
    }

}