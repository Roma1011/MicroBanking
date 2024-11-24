using Microsoft.Extensions.DependencyInjection;
using Transfer.Data;

namespace Transfer.Application;
public static class Extension
{
    public static IServiceCollection AddTransferServices(this IServiceCollection collection)
    {
        collection.AddTransferDataContext();
        return collection;
    }
}