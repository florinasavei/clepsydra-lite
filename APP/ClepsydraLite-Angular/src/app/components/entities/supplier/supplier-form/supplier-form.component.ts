import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SupplierService } from 'src/app/services/entities/supplier/supplier.service';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';

@Component({
  selector: 'app-supplier-form',
  templateUrl: './supplier-form.component.html',
  styleUrls: ['./supplier-form.component.scss']
})
export class SupplierFormComponent implements OnInit {

  constructor(public service: SupplierService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(suppliersForm?: NgForm) {
    if (suppliersForm != null) 
    suppliersForm.form.reset();

    this.service.suppliersFormData = {
      id: 0,
      name : null,
      description: null,
    }
  }

  onSubmit(suppliersForm:NgForm){
   //TODO: foinish this
  }

}
