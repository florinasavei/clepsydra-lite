import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';
import { ShopsContainerComponent } from './components/entities/shop/shops-container/shops-container.component';


const routes: Routes = [
  {
    path: 'suppliers', component: SuppliersContainerComponent, data: { breadcrumb: 'Suppliers' },
    children: [
      {
        path: ':categories', component: SuppliersContainerComponent, data: { breadcrumb: 'Product Categories' },        
      }]
  },
  { path: 'shops', component: ShopsContainerComponent, data: { breadcrumb: 'Shops' } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
