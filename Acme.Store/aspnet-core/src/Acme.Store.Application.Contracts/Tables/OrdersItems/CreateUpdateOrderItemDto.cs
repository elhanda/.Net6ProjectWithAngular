using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Store.Tables.OrdersItems
{
    public class CreateUpdateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
