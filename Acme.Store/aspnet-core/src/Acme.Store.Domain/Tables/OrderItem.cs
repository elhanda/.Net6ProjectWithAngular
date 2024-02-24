using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Acme.Store.Tables
{
    public class OrderItem : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        // Other properties as needed...
        private OrderItem()
        {
            // Required by EF
        }
        public OrderItem(Guid productId, int quantity, double price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }

    public class OrderItemValidator : FluentValidation.AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0);
             RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
