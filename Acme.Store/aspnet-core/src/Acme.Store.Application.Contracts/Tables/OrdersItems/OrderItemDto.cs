using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.Store.Tables.OrdersItems
{
    public class OrderItemDto : AuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; } //Defined by the IMultiTenant interface

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
