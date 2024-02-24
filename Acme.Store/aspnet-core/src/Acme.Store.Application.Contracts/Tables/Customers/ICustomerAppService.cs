using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Store.Tables.Customers
{
    public interface ICustomerAppService :
       ICrudAppService< //Defines CRUD methods
         CustomerDto, //Used to show books
           Guid, //Primary key of the book entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateCustomerDto> //Used to create/update a book
    {
    }
}
