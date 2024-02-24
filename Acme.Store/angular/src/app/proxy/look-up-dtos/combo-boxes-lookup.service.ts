import type { CustomerLookUpDto, OrderLookupDto, ProductLookupDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ComboBoxesLookupService {
  apiName = 'Default';
  

  getCustomerLookup = () =>
    this.restService.request<any, ListResultDto<CustomerLookUpDto>>({
      method: 'GET',
      url: '/api/app/combo-boxes-lookup/customer-lookup',
    },
    { apiName: this.apiName });
  

  getOrderLookup = () =>
    this.restService.request<any, ListResultDto<OrderLookupDto>>({
      method: 'GET',
      url: '/api/app/combo-boxes-lookup/order-lookup',
    },
    { apiName: this.apiName });
  

  getProductLookup = () =>
    this.restService.request<any, ListResultDto<ProductLookupDto>>({
      method: 'GET',
      url: '/api/app/combo-boxes-lookup/product-lookup',
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
