import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';
import { ShopsContainerComponent } from './components/entities/shop/shops-container/shops-container.component';
import { SupplierProductCategoriesContainerComponent } from './components/entities/supplier/product-categories/supplier-product-categories-container/supplier-product-categories-container.component';
import { SupplierDetailsComponent } from './components/entities/supplier/supplier-details/supplier-details.component';


const routes: Routes = [
  {
    path: 'supplier', data: { breadcrumb: 'Suppliers' }, children: [
      {
        path: '', pathMatch: "full", component: SuppliersContainerComponent
      },
      {
        path: ':id',
        data: { breadcrumb: '' },
        children: [
          { path: '', pathMatch: "full", redirectTo: "details", }, // supplier/5/details            
          {
            path: 'details', data: { breadcrumb: 'Details' }, children: [
              { path: '', pathMatch: "full",  component: SupplierDetailsComponent }, // supplier/5/details
              {
                path: 'product-categories',  data: { breadcrumb: 'Product Categories' }, children: [
                  { path: '', pathMatch: "full", component: SupplierProductCategoriesContainerComponent },
                ]
              },
            ]
          },
        ]
      }]
  },
  { path: 'shops', component: ShopsContainerComponent, data: { breadcrumb: 'Shops' }, },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
