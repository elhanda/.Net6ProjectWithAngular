using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Store.Tables.Orders
{
    public class CreateUpdateOrderDto
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
