using System.Threading.Tasks;

namespace Acme.Store.Data;

public interface IStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
