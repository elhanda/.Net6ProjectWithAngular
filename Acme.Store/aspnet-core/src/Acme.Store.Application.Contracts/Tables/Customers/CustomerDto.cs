using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.Store.Tables.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {

        public Guid? TenantId { get; set; } //Defined by the IMultiTenant interface

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
