import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Store',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:49159/',
    redirectUri: baseUrl,
    clientId: 'Store_App',
    responseType: 'code',
    scope: 'offline_access Store',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:49159',
      rootNamespace: 'Acme.Store',
    },
  },
} as Environment;
