import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Store',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44393/',
    redirectUri: baseUrl,
    clientId: 'Store_App',
    responseType: 'code',
    scope: 'offline_access Store',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44393',
      rootNamespace: 'Acme.Store',
    },
  },
} as Environment;
