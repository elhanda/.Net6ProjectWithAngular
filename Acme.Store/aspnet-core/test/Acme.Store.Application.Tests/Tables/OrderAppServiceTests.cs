using Acme.Store.Tables.Orders;
using Acme.Store.Tables.OrdersItems;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.Store.Tables
{
    public class OrderAppServiceTests : StoreApplicationTestBase
    {
        private readonly IOrderAppService _OrderAppService;

        public OrderAppServiceTests()
        {
            _OrderAppService = GetRequiredService<IOrderAppService>();
        }

     
    }
}