import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SuppliersContainerComponent } from './components/entities/supplier/suppliers-container/suppliers-container.component';
import { SuppliersListComponent } from './components/entities/supplier/suppliers-list/suppliers-list.component';
import { SupplierFormComponent } from './components/entities/supplier/supplier-form/supplier-form.component';

@NgModule({
  declarations: [
    AppComponent,
    SuppliersContainerComponent,
    SuppliersListComponent,
    SupplierFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
