namespace Acme.Store.Tables.Orders
{
     
    using Acme.Store.Tables.OrdersItems;
    using System; 
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;
    using Volo.Abp.Domain.Repositories;


    public class OrderItemAppService :
        CrudAppService<
            OrderItem, //The Book entity
            OrderItemDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderItemDto>, //Used to create/update a book
        IOrderItemAppService //implement the IBookAppService
    {
        public OrderItemAppService(IRepository<OrderItem, Guid> repository)
            : base(repository)
        {

        }
    }
}