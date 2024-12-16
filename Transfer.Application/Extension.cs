using Microsoft.Extensions.DependencyInjection;
using Transfer.Application.Interfaces;
using Transfer.Application.Services;
using Transfer.Data;

namespace Transfer.Application;
public static class Extension
{
    public static IServiceCollection AddTransferServices(this IServiceCollection collection)
    {
        collection.AddTransient<ITransferService, TransferService>();
        collection.AddTransferDataContext();
        return collection;
    }
}