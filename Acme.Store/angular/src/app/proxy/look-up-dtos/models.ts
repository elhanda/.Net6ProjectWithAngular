import type { EntityDto } from '@abp/ng.core';

export interface CustomerLookUpDto extends EntityDto<string> {
  name?: string;
  email?: string;
}

export interface OrderLookupDto extends EntityDto<string> {
  orderDate?: string;
  totalAmount: number;
}

export interface ProductLookupDto extends EntityDto<string> {
  name?: string;
  description?: string;
  price: number;
}
