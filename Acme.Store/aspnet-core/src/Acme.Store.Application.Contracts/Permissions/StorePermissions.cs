namespace Acme.Store.Permissions;

public static class StorePermissions
{
    public const string GroupName = "Store";


    #region ---------------- /* Tables permissions  */ ------------------------

    public static class Product
    {
        public const string Default = GroupName + ".Product";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class OrderItem
    {
        public const string Default = GroupName + ".OrderItem";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Order
    {
        public const string Default = GroupName + ".Order";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Customer
    {
        public const string Default = GroupName + ".Customer";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    #endregion

}
