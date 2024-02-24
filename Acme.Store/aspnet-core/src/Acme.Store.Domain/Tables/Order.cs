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
    public class Order : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        // Navigation property to order items
        public ICollection<OrderItem> Items { get; set; }

        private Order()
        {
            // Required by EF
        }

        public Order(Guid id, Guid customerId, DateTime orderDate, double totalAmount)
            : base(id)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }
    }

    public class OrderValidator : FluentValidation.AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.OrderDate).NotEmpty();
            RuleFor(x => x.TotalAmount).GreaterThan(0);
        }
    }
}
