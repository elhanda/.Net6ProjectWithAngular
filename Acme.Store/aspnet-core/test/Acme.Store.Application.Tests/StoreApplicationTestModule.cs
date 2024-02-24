using Volo.Abp.Modularity;

namespace Acme.Store;

[DependsOn(
    typeof(StoreApplicationModule),
    typeof(StoreDomainTestModule)
    )]
public class StoreApplicationTestModule : AbpModule
{

}
