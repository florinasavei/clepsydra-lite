import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';


const routes: Routes = [
  { path: 'suppliers', component: SuppliersContainerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
