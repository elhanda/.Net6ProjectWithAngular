using Acme.Store.Tables.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Store.Tables.Orders
{
    public interface IOrderAppService :
       ICrudAppService< //Defines CRUD methods
         OrderDto, //Used to show books
           Guid, //Primary key of the book entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateOrderDto> //Used to create/update a book
    {
    }
}