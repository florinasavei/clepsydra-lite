import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APPSettings } from 'src/settings/api-settings';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  readonly rootURL = APPSettings.apiURL + '/supplier';
  suppliersFormData: Supplier;
  suppliersList: Supplier[];
  currentSupplier: Supplier;
  formInEdit: boolean = false;

  constructor(private http: HttpClient) { }

  postSupplier() {
    return this.http.post(this.rootURL + '/', this.suppliersFormData);
  }

  putSupplier() {
    return this.http.put(this.rootURL + '/' + this.suppliersFormData.id, this.suppliersFormData);
  }

  deleteSupplier(id) {
    return this.http.delete(this.rootURL + '/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL)
      .toPromise()
      .then(res =>
        this.suppliersList = res as Supplier[]
      );
  }

  getById(id) {
    this.http.get(this.rootURL + "/" + id)
      .toPromise()
      .then(res => {
        this.currentSupplier = res as Supplier
      });
  }
}