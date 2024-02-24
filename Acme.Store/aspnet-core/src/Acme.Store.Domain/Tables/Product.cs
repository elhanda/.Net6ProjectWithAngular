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
    public class Product : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        private Product()
        {
            // Required by EF
        }

        public Product(Guid id, string name, string description, double price)
            : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }

    public class ProductValidator : FluentValidation.AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
