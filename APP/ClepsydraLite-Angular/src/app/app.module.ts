import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomMaterialModule } from './material.module';

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
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    MatNativeDateModule,
    FlexLayoutModule,
    CustomMaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

