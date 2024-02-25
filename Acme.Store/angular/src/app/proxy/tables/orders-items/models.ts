import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateOrderItemDto {
  productId?: string;
  quantity: number;
  price: number;
}

export interface OrderItemDto extends AuditedEntityDto<string> {
  tenantId?: string;
  productId?: string;
  productName?: string;
  quantity: number;
  price: number;
}
