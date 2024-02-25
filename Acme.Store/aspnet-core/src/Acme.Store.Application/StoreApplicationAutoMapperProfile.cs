using Acme.Store.LookUpDtos;
using Acme.Store.Tables;
using Acme.Store.Tables.Customers;
using Acme.Store.Tables.Orders;
using Acme.Store.Tables.OrdersItems;
using Acme.Store.Tables.Products;
using AutoMapper;
using System.Diagnostics;

namespace Acme.Store;

public class StoreApplicationAutoMapperProfile : Profile
{
    public StoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
         CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<ProductLookupDto, Product>();
        CreateMap<Product, ProductLookupDto>();

        CreateMap<Order, OrderDto>();
         CreateMap<CreateUpdateOrderDto, Order>();
        CreateMap<OrderLookupDto, Order>();
        CreateMap<Order, OrderLookupDto>();

        CreateMap<OrderItem, OrderItemDto>();
         CreateMap<CreateUpdateOrderItemDto, OrderItem>();
 
        CreateMap<Customer, CustomerDto>();
         CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<CustomerLookUpDto, Customer>();
        CreateMap<Customer,CustomerLookUpDto >();


    }
}
