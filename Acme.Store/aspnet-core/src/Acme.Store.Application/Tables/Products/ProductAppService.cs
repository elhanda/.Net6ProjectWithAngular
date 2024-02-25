 namespace Acme.Store.Tables.Products
{
    using Acme.Store.Permissions;
    using Microsoft.AspNetCore.Authorization;
    using System;
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;
    using Volo.Abp.Domain.Repositories;

    [Authorize(StorePermissions.Product.Default)]

    public class ProductAppService :
        CrudAppService<
            Product, //The Book entity
            ProductDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateProductDto>, //Used to create/update a book
        IProductAppService //implement the IBookAppService
    {
        public ProductAppService(IRepository<Product, Guid> repository)
            : base(repository)
        {
            GetPolicyName = StorePermissions.Product.Default;
            GetListPolicyName = StorePermissions.Product.Default;
            CreatePolicyName = StorePermissions.Product.Create;
            UpdatePolicyName = StorePermissions.Product.Edit;
            DeletePolicyName = StorePermissions.Product.Create;

        }
    }
}