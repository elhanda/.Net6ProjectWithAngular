using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.Store.Tables.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; } //Defined by the IMultiTenant interface

        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
