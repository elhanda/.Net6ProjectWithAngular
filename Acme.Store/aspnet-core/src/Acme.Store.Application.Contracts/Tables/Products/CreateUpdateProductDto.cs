using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Store.Tables.Products
{
    public class CreateUpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
