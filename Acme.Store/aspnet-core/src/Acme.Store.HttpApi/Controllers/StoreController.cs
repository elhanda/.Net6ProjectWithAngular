using Acme.Store.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Store.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StoreController : AbpControllerBase
{
    protected StoreController()
    {
        LocalizationResource = typeof(StoreResource);
    }
}
