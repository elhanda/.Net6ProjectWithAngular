import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerDto {
  name?: string;
  email?: string;
}

export interface CustomerDto extends AuditedEntityDto<string> {
  tenantId?: string;
  name?: string;
  email?: string;
}
