import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/Customers',
        name: '::Store',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/Customer',
        name: '::Customer',
        parentName: '::Store',
        layout: eLayoutType.application,
      },
      {
        path: '/Products',
        name: '::Products',
        parentName: '::Store',
        layout: eLayoutType.application,
      },
      {
        path: '/Order',
        name: '::Order',
        parentName: '::Store',
        layout: eLayoutType.application,
      },
    ]);
  };
}
