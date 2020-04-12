import { Component, OnInit } from '@angular/core';
import { ShopService } from 'src/app/services/entities/shop/shop.service';
import { Shop } from 'src/app/models/entities/shop/shop.model';

@Component({
  selector: 'app-shops-list',
  templateUrl: './shops-list.component.html',
  styles: [
  ]
})
export class ShopsListComponent implements OnInit {

  constructor(public service: ShopService) { 
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(sup:Shop){
    this.service.shopFormData =  Object.assign({}, sup);
  }

  onDelete(id){
    if(confirm("Are you sure you want to delete?"))
    this.service.deleteShop(id)
    .subscribe(res => {
      this.service.refreshList();
    },
      err=>{
        console.info(err)
      })
  }

}
