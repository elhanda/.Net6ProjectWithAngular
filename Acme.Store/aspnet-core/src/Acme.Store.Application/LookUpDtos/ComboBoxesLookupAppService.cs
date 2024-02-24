using Acme.Store.Tables;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Acme.Store.LookUpDtos
{
    public class ComboBoxesLookupAppService : ApplicationService
    {
        private readonly IRepository<Order, Guid> _OrderRepository;
        private readonly IRepository<Customer, Guid> _CustomerRepository;
        private readonly IRepository<Product, Guid> _ProductRepository;
        public ComboBoxesLookupAppService(IRepository<Order, Guid> OrderRepository,IRepository<Customer, Guid> CustomerRepository, IRepository<Product, Guid> ProductRepository)
        {
            _OrderRepository = OrderRepository;
            _CustomerRepository = CustomerRepository;
            _ProductRepository = ProductRepository;
        }
        public async Task<ListResultDto<OrderLookupDto>> GetOrderLookupAsync()
        {
            var authors = await _OrderRepository.GetListAsync();
            return new ListResultDto<OrderLookupDto>(
                ObjectMapper.Map<List<Order>, List<OrderLookupDto>>(authors));
        }
        public async Task<ListResultDto<CustomerLookUpDto>> GetCustomerLookupAsync()
        {
            var authors = await _CustomerRepository.GetListAsync();
            return new ListResultDto<CustomerLookUpDto>(
                ObjectMapper.Map<List<Customer>, List<CustomerLookUpDto>>(authors));
        }
        public async Task<ListResultDto<ProductLookupDto>> GetProductLookupAsync()
        {
            var authors = await _ProductRepository.GetListAsync();
            return new ListResultDto<ProductLookupDto>(
                ObjectMapper.Map<List<Product>, List<ProductLookupDto>>(authors));
        }


    }
}
