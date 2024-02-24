using Acme.Store.Tables.OrdersItems;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;
using Shouldly;

namespace Acme.Store.Tables
{
    public class OrderItemsAppServiceTests : StoreApplicationTestBase
    {
        private readonly IOrderItemAppService _OrderItemAppService;

        public OrderItemsAppServiceTests()
        {
            _OrderItemAppService = GetRequiredService<IOrderItemAppService>();
        }

     
    }
}