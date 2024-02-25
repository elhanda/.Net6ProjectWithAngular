namespace Acme.Store.Tables.Orders
{
    using Acme.Store.Tables.OrdersItems;
    using System;
    using System.Threading.Tasks;
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;
    using Volo.Abp.Domain.Entities;
    using Volo.Abp.Domain.Repositories;  
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using Acme.Store.Permissions;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(StorePermissions.Order.Default)]

    public class OrderAppService :
        CrudAppService<
            Order, //The Book entity
            OrderDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderDto>, //Used to create/update a book
        IOrderAppService //implement the IBookAppService
    {
        private readonly IRepository<Customer, Guid> _CustomerRepository;
        public OrderAppService(IRepository<Order, Guid> repository, IRepository<Customer, Guid> customerRepository)
            : base(repository)
        {
            _CustomerRepository = customerRepository;
            GetPolicyName = StorePermissions.Order.Default;
            GetListPolicyName = StorePermissions.Order.Default;
            CreatePolicyName = StorePermissions.Order.Create;
            UpdatePolicyName = StorePermissions.Order.Edit;
            DeletePolicyName = StorePermissions.Order.Create;
        }
        public override async Task<OrderDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from Order in queryable
                        join product in await _CustomerRepository.GetQueryableAsync() on Order.CustomerId equals product.Id
                        where Order.Id == id
                        select new { Order, product };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            var bookDto = ObjectMapper.Map<Order, OrderDto>(queryResult.Order);
            bookDto.CustomerName = queryResult.product.Name;
            return bookDto;
        }

        public override async Task<PagedResultDto<OrderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from Order in queryable
                        join product in await _CustomerRepository.GetQueryableAsync() on Order.CustomerId equals product.Id
                        select new { Order, product };

            //Paging
            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Order, OrderDto>(x.Order);
                bookDto.CustomerName = x.product.Name;
                return bookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<OrderDto>(
                totalCount,
                bookDtos
            );
        }


    }
}