using Acme.Store.Tables.Products;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;
namespace Acme.Store.Tables
{
    public class ProductsAppServiceTests : StoreApplicationTestBase
    {
        private readonly IProductAppService _ProductAppService;

        public ProductsAppServiceTests()
        {
            _ProductAppService = GetRequiredService<IProductAppService>();
        }
      
        [Fact]
        public async Task Should_Create_A_Valid_Product()
        {
            //Act
            var result = await _ProductAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "Milk",
                    Price = 10,
                    Description = "Milk 1/2"
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Milk");
        }
    }
}