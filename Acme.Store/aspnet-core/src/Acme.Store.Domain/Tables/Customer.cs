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
    public class Customer : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private Customer()
        {
            // Required by EF
        }

        public Customer(Guid id, string name, string email)
            : base(id)
        {
            Name = name;
            Email = Email;
        }
    }

    public class CustomerValidator : FluentValidation.AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
        }
    }
}
