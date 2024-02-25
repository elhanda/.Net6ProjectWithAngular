namespace Acme.Store.Tables.Orders
{
     
    using Acme.Store.Tables.OrdersItems;
    using System;
    using System.Threading.Tasks;
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;
    using Volo.Abp.Domain.Entities;
    using Volo.Abp.Domain.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using Microsoft.AspNetCore.Authorization;
    using Acme.Store.Permissions;
    [Authorize(StorePermissions.OrderItem.Default)]

    public class OrderItemAppService :
        CrudAppService<
            OrderItem, //The Book entity
            OrderItemDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderItemDto>, //Used to create/update a book
        IOrderItemAppService //implement the IBookAppService
    {
        private readonly IRepository<Product, Guid> _ProductRepository;

 
        public OrderItemAppService(IRepository<OrderItem, Guid> repository, IRepository<Product, Guid> productRepository)
            : base(repository)
        {
            _ProductRepository = productRepository;
            GetPolicyName = StorePermissions.OrderItem.Default;
            GetListPolicyName = StorePermissions.OrderItem.Default;
            CreatePolicyName = StorePermissions.OrderItem.Create;
            UpdatePolicyName = StorePermissions.OrderItem.Edit;
            DeletePolicyName = StorePermissions.OrderItem.Create;
        }
        public override async Task<OrderItemDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from OrderItem in queryable
                        join product in await _ProductRepository.GetQueryableAsync() on OrderItem.ProductId equals product.Id
                        where OrderItem.Id == id
                        select new { OrderItem, product };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(OrderItem), id);
            }

            var bookDto = ObjectMapper.Map<OrderItem, OrderItemDto>(queryResult.OrderItem);
            bookDto.ProductName = queryResult.product.Name;
            return bookDto;
        }

        public override async Task<PagedResultDto<OrderItemDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from OrderItem in queryable
                        join product in await _ProductRepository.GetQueryableAsync() on OrderItem.ProductId equals product.Id
                        select new { OrderItem, product };

            //Paging
            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<OrderItem, OrderItemDto>(x.OrderItem);
                bookDto.ProductName = x.product.Name;
                return bookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<OrderItemDto>(
                totalCount,
                bookDtos
            );
        }



    }
}