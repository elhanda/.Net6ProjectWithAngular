using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.Store.Tables.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {

        public Guid? TenantId { get; set; } //Defined by the IMultiTenant interface

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
