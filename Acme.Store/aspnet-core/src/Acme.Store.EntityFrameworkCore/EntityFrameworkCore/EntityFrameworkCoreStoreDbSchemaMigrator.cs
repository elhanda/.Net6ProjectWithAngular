using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.Store.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.Store.EntityFrameworkCore;

public class EntityFrameworkCoreStoreDbSchemaMigrator
    : IStoreDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {

        await _serviceProvider
           .GetRequiredService<StoreDbContext>()
           .Database
           .MigrateAsync();

        var dbContext = _serviceProvider.GetRequiredService<StoreDbContext>();
        await dbContext.Database.MigrateAsync();

        await _serviceProvider.GetRequiredService<StoreDbContext>().Database.MigrateAsync();




    }
}
