import { Injectable } from '@angular/core';
import { APPSettings } from 'src/settings/api-settings';
import { Shop } from 'src/app/models/entities/shop/shop.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  readonly rootURL = APPSettings.apiURL + '/shop';
  shopFormData: Shop;
  shopsList: Shop[];
  
  constructor(private http: HttpClient) { }

  postShop() {
    return this.http.post(this.rootURL + '/', this.shopFormData);
  }

  putShop() {
    return this.http.put(this.rootURL + '/' + this.shopFormData.id, this.shopFormData);
  }

  deleteShop(id) {
    return this.http.delete(this.rootURL + '/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL)
      .toPromise()
      .then(res =>
        this.shopsList = res as Shop[]
      );
  }

}
