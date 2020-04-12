import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';
import { ShopsContainerComponent } from './components/entities/shop/shops-container/shops-container.component';


const routes: Routes = [
  { path: 'suppliers', component: SuppliersContainerComponent },
  { path: 'shops', component: ShopsContainerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
