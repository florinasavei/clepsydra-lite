import { Component, OnInit } from '@angular/core';
import { SupplierProductCategoriesService } from 'src/app/services/entities/supplier/product-categories/supplier-product-categories.service';

@Component({
  selector: 'app-supplier-product-categories-container',
  templateUrl: './supplier-product-categories-container.component.html',
  styles: [
  ]
})
export class SupplierProductCategoriesContainerComponent implements OnInit {

  constructor(public service: SupplierProductCategoriesService) { }

  ngOnInit(): void {
    this.service.formInEdit = false;
  }
  
  toggleForm = function(){
    this.service.formInEdit = !this.service.formInEdit;
  };

}
