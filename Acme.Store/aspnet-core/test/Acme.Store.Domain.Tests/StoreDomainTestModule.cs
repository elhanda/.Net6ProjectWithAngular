using Acme.Store.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.Store;

[DependsOn(
    typeof(StoreEntityFrameworkCoreTestModule)
    )]
public class StoreDomainTestModule : AbpModule
{

}
