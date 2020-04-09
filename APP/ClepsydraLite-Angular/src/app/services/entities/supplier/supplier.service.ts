import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APPSettings } from 'src/settings/api-settings';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  readonly rootURL = APPSettings.apiURL + '/supplier';
  suppliersFormData: Supplier;
  suppliersList: Supplier[];
  
  constructor(private http: HttpClient) { }

  refreshList() {
    debugger;
    this.http.get(this.rootURL)
      .toPromise()
      .then(res =>
        this.suppliersList = res as Supplier[]
      );
  }

}
