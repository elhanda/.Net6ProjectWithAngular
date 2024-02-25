namespace Acme.Store.Tables.Customers
{
    using Acme.Store.Permissions;
    using Microsoft.AspNetCore.Authorization;
    using System;
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;
    using Volo.Abp.Domain.Repositories;


    [Authorize(StorePermissions.Customer.Default)]

    public class CustomerAppService :
        CrudAppService<
            Customer, //The Book entity
            CustomerDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCustomerDto>, //Used to create/update a book
        ICustomerAppService //implement the IBookAppService
    {
        public CustomerAppService(IRepository<Customer, Guid> repository)
            : base(repository)
        {
            GetPolicyName = StorePermissions.Customer.Default;
            GetListPolicyName = StorePermissions.Customer.Default;
            CreatePolicyName = StorePermissions.Customer.Create;
            UpdatePolicyName = StorePermissions.Customer.Edit;
            DeletePolicyName = StorePermissions.Customer.Create;
        }
    }
}