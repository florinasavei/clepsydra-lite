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
    if(!suppliersForm.value.Id){
      this.insertRecord(suppliersForm);
    } else{
      this.updateRecord(suppliersForm);
    } 
  }

  insertRecord(suppliersForm:NgForm){
    this.service.postSupplier().subscribe(
      res => {
        this.resetForm(suppliersForm);
        this.service.refreshList();
      },
      err =>{
        console.info(err);
      }
    )
  }

  updateRecord(suppliersForm:NgForm){
    this.service.putSupplier().subscribe(
      res => {
        this.resetForm(suppliersForm);
        this.service.refreshList();
      },
      err =>{
        console.info(err);
      }
    )
  }

}
