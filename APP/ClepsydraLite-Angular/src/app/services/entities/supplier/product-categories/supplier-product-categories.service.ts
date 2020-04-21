import { Injectable } from '@angular/core';
import { APPSettings } from 'src/settings/api-settings';
import { HttpClient } from '@angular/common/http';
import { SupplierProductCategory } from 'src/app/models/entities/supplier/product-category/supplier-product-category.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierProductCategoriesService {

  readonly rootURL = APPSettings.apiURL + '/supplier';
  supplierProducCategoriesFormData: SupplierProductCategory;
  suppliersProducCategoriesList: SupplierProductCategory[];
  currentSupplierProductCategory: SupplierProductCategory;
  formInEdit: boolean = false;

  constructor(private http: HttpClient) { }

  refreshList(supplierId) {
    debugger;
    this.http.get(this.rootURL + "/" + supplierId + "/SupplierProductCategory")
      .toPromise()
      .then(res =>
        this.suppliersProducCategoriesList = res as SupplierProductCategory[]
      );
  }

  postSupplierProductCategory(supplierId) {
    return this.http.post(this.rootURL + "/" + supplierId + "/SupplierProductCategory", this.supplierProducCategoriesFormData);
  }

  postCurrentSupplier(supplierId) {
    return this.http.post(this.rootURL + "/" + supplierId + "/SupplierProductCategory", this.currentSupplierProductCategory);
  }

  putSupplierProductCategory(supplierId) {
    return this.http.put(this.rootURL + '/' + supplierId + "/SupplierProductCategory/"+ this.supplierProducCategoriesFormData.id, this.supplierProducCategoriesFormData);
  }
  
  putCurrentSupplierProductCategory(supplierId) {
    return this.http.put(this.rootURL + '/' + supplierId + "/SupplierProductCategory/" + this.currentSupplierProductCategory.id, this.currentSupplierProductCategory);
  }

  deleteSupplier(supplierId, id) {
    return this.http.delete(this.rootURL + '/' + supplierId + "/SupplierProductCategory/" + id);
  }


  getById(supplierId, id) {
    this.http.get(this.rootURL + "/" + id)
      .toPromise()
      .then(res => {
        this.currentSupplierProductCategory = res as SupplierProductCategory
      });
  }
}
