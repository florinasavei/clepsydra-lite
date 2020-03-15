import { Injectable } from '@angular/core';
import { APPSettings } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  readonly rootURL = APPSettings.apiURL + '/suppliers';
  
  constructor() { }


}
