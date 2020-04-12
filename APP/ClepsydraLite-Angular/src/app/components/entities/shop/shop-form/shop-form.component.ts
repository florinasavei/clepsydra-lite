import { Component, OnInit } from '@angular/core';
import { ShopService } from 'src/app/services/entities/shop/shop.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-shop-form',
  templateUrl: './shop-form.component.html',
  styles: [
  ]
})
export class ShopFormComponent implements OnInit {

  constructor(public service: ShopService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(shopForm?: NgForm) {
    if (shopForm != null) 
    shopForm.form.reset();

    this.service.shopFormData = {
      id: 0,
      name : null,
      description: null,
      email: null,
      telephone: null
    }
  }

  onSubmit(shopForm:NgForm){
    if(!shopForm.value.Id){
      this.insertRecord(shopForm);
    } else{
      this.updateRecord(shopForm);
    } 
  }

  insertRecord(shopForm:NgForm){
    this.service.postShop().subscribe(
      res => {
        this.resetForm(shopForm);
        this.service.refreshList();
      },
      err =>{
        console.info(err);
      }
    )
  }

  updateRecord(shopForm:NgForm){
    this.service.putShop().subscribe(
      res => {
        this.resetForm(shopForm);
        this.service.refreshList();
      },
      err =>{
        console.info(err);
      }
    )
  }

}
