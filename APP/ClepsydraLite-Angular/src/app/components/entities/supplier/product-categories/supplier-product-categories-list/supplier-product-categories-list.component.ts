import { Component, OnInit } from '@angular/core';
import { SupplierProductCategoriesService } from 'src/app/services/entities/supplier/product-categories/supplier-product-categories.service';
import { ActivatedRoute } from '@angular/router';
import { SupplierProductCategory } from 'src/app/models/entities/supplier/product-category/supplier-product-category.model';

@Component({
  selector: 'app-supplier-product-categories-list',
  templateUrl: './supplier-product-categories-list.component.html',
  styles: [
  ]
})
export class SupplierProductCategoriesListComponent implements OnInit {

  constructor(public service: SupplierProductCategoriesService,  private route: ActivatedRoute) { 
  }

  supplierId;

  ngOnInit(): void {    
    debugger;
    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })

    this.service.refreshList(this.supplierId);
  }

  populateForm(supCat:SupplierProductCategory){
    this.service.formInEdit = true;
    setTimeout(() => { //TODO: figure out a smarter way than using timeouts
      this.service.supplierProducCategoriesFormData =  Object.assign({}, supCat);
    }, 0);

  }

  onDelete(id){
    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })

    if(confirm("Are you sure you want to delete?"))
    this.service.deleteSupplier(this.supplierId, id)
    .subscribe(res => {
      this.service.refreshList(this.supplierId);
    },
      err=>{
        console.info(err)
      })
  }

}
