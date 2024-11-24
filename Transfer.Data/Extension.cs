using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.Interfaces;

[assembly:InternalsVisibleTo("Transfer.Application")]
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
}