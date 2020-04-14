import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';
import { ShopsContainerComponent } from './components/entities/shop/shops-container/shops-container.component';
import { SupplierProductCategoriesContainerComponent } from './components/entities/supplier/product-categories/supplier-product-categories-container/supplier-product-categories-container.component';
import { SupplierDetailsComponent } from './components/entities/supplier/supplier-details/supplier-details.component';


const routes: Routes = [
  { path: 'suppliers', component: SuppliersContainerComponent, data: { breadcrumb: 'Suppliers' } },
  {
    path: 'suppliers/:id', component: SupplierDetailsComponent, data: { breadcrumb: 'Supplier' },
    children: [
      { path: '', component: SupplierDetailsComponent },
      { path: 'categories', component: SupplierProductCategoriesContainerComponent, data: { breadcrumb: 'Product Categories' } },
    ]
  },
  { path: 'shops', component: ShopsContainerComponent, data: { breadcrumb: 'Shops' } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
