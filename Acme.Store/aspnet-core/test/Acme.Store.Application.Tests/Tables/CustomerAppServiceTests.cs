using Acme.Store.Tables.Customers;
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
    public class CustomerAppServiceTests : StoreApplicationTestBase
    {
        private readonly ICustomerAppService _CustomerAppService;

        public CustomerAppServiceTests()
        {
            _CustomerAppService = GetRequiredService<ICustomerAppService>();
        }

        [Fact]
        public async Task Should_Create_A_Valid_Customer()
        {
            //Act
            var result = await _CustomerAppService.CreateAsync(
                new CreateUpdateCustomerDto
                {
                    Name = "Ismail",
                    Email = "nchinoubi@gmail.com",
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Ismail");
        }
    }
}