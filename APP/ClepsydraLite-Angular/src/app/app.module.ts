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
import { FontAwesomeModule,FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { ShopsContainerComponent } from './components/entities/shop/shops-container/shops-container.component';
import { ShopsListComponent } from './components/entities/shop/shops-list/shops-list.component';
import { ShopFormComponent } from './components/entities/shop/shop-form/shop-form.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import {BreadcrumbModule} from 'angular-crumbs';
import { SupplierProductCategoriesContainerComponent } from './components/entities/supplier/product-categories/supplier-product-categories-container/supplier-product-categories-container.component';
import { SupplierDetailsComponent } from './components/entities/supplier/supplier-details/supplier-details.component';
import { ProductCategoriesListComponent } from './components/entities/supplier/product-categories/product-categories-list/product-categories-list.component';

@NgModule({
  declarations: [
    AppComponent,
    SuppliersContainerComponent,
    SuppliersListComponent,
    SupplierFormComponent,
    ShopsContainerComponent,
    ShopsListComponent,
    ShopFormComponent,
    NavbarComponent,
    SupplierProductCategoriesContainerComponent,
    SupplierDetailsComponent,
    ProductCategoriesListComponent
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
    FontAwesomeModule,
    BreadcrumbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far);
  }
}

