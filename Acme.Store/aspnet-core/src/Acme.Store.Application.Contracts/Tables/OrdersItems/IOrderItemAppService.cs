using Acme.Store.Tables.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Store.Tables.OrdersItems
{
    public interface IOrderItemAppService :
       ICrudAppService< //Defines CRUD methods
         OrderItemDto, //Used to show books
           Guid, //Primary key of the book entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateOrderItemDto> //Used to create/update a book
    {
    }
}