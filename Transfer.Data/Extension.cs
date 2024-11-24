using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transfer.Data.Context;

namespace Transfer.Data;

public static class Extension
{
    public static IServiceCollection AddDataContext(this IServiceCollection collection)
    {
        collection.AddDbContext<TransferDbContext>(options =>
        {
            options.UseSqlServer("Data source=.; Initial Catalog=MicroTransferDb;Integrated Security = SSPI;Trust Server Certificate=True");
        });
        return collection;
    }
}