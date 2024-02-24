using Acme.Store.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.Store.Permissions;

public class StorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StorePermissions.GroupName); 

        #region ---------------- /* Tables permissions  */ ------------------------

        var ProductPermission = myGroup.AddPermission(StorePermissions.Product.Default, L("Permission:Product"));
        ProductPermission.AddChild(StorePermissions.Product.Create, L("Permission:Create"));
        ProductPermission.AddChild(StorePermissions.Product.Edit, L("Permission:Edit"));
        ProductPermission.AddChild(StorePermissions.Product.Delete, L("Permission:Delete"));

        var CustomerPermission = myGroup.AddPermission(StorePermissions.Customer.Default, L("Permission:Customer"));
        CustomerPermission.AddChild(StorePermissions.Customer.Create, L("Permission:Create"));
        CustomerPermission.AddChild(StorePermissions.Customer.Edit, L("Permission:Edit"));
        CustomerPermission.AddChild(StorePermissions.Customer.Delete, L("Permission:Delete"));

        var OrderPermission = myGroup.AddPermission(StorePermissions.Order.Default, L("Permission:Order"));
        OrderPermission.AddChild(StorePermissions.Order.Create, L("Permission:Create"));
        OrderPermission.AddChild(StorePermissions.Order.Edit, L("Permission:Edit"));
        CustomerPermission.AddChild(StorePermissions.Order.Delete, L("Permission:Delete"));

        var OrderItemPermission = myGroup.AddPermission(StorePermissions.OrderItem.Default, L("Permission:OrderItem"));
        OrderItemPermission.AddChild(StorePermissions.OrderItem.Create, L("Permission:Create"));
        OrderItemPermission.AddChild(StorePermissions.OrderItem.Edit, L("Permission:Edit"));
        OrderItemPermission.AddChild(StorePermissions.OrderItem.Delete, L("Permission:Delete"));
        #endregion


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreResource>(name);
    }
}
