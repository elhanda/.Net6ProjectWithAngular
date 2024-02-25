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
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/Customers',
        name: '::Menu:Store',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/Customer',
        name: '::Menu:Customer',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
      },
      {
        path: '/Products',
        name: '::Menu:Products',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
      },
      {
        path: '/Order',
        name: '::Menu:Order',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
      },
    ]);
  };
}
