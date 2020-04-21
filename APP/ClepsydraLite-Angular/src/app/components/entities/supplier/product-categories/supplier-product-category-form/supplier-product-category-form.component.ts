import { Component, OnInit } from '@angular/core';
import { SupplierProductCategoriesService } from 'src/app/services/entities/supplier/product-categories/supplier-product-categories.service';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-supplier-product-category-form',
  templateUrl: './supplier-product-category-form.component.html',
  styles: [
  ]
})
export class SupplierProductCategoryFormComponent implements OnInit {

  constructor(public service: SupplierProductCategoriesService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })
    this.service.formInEdit = true;
    this.resetForm();
  }

  supplierId;

  resetForm(supplierProducCategoriesForm?: NgForm) {
    if (supplierProducCategoriesForm != null)
    supplierProducCategoriesForm.form.reset();

    this.service.supplierProducCategoriesFormData = {
      supplierId: 0,
      id: 0,
      name: null,
      description: null,
    }

    //this.service.formInEdit = false;
  }

  clearForm(form: any) {
    form.reset();
    this.service.formInEdit = false;
  }

  onSubmit(supplierProducCategoriesForm: NgForm) {

    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })
    debugger;

    if (!supplierProducCategoriesForm.value.Id) {
      this.insertRecord(supplierProducCategoriesForm);
    } else {
      this.updateRecord(supplierProducCategoriesForm);
    }
    this.service.formInEdit = false;
  }

  insertRecord(supplierProducCategoriesForm: NgForm) {

    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })

    this.service.postSupplierProductCategory(this.supplierId).subscribe(
      res => {
        this.resetForm(supplierProducCategoriesForm);
        this.service.refreshList(this.supplierId);
      },
      err => {
        console.info(err);
      }
    )
  }

  updateRecord(supplierProducCategoriesForm: NgForm) {
    this.service.putSupplierProductCategory(this.supplierId).subscribe(
      res => {
        this.resetForm(supplierProducCategoriesForm);
        this.service.refreshList(this.supplierId);
      },
      err => {
        console.info(err);
      }
    )
  }
}
