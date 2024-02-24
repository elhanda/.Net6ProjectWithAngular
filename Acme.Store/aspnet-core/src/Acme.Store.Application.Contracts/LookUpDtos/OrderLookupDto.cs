using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.Store.LookUpDtos
{
    public class OrderLookupDto : EntityDto<Guid>
    {
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
