import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/entities/supplier/supplier.service';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styles: [
  ]
})
export class SupplierDetailsComponent implements OnInit {

  constructor(public service: SupplierService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.service.currentSupplier = {
      id: 0,
      name: null,
      description: null,
      email: null,
      telephone: null
    }

    this.populateSupplirForm()
  
  }

  populateSupplirForm(){
    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })
    
    this.service.getById(this.supplierId);
  }

  supplierId;
  
  inEdit: boolean = false;

  toggleEdit(value: boolean){
    this.inEdit = value;
  }

  onSubmit(suppliersForm: NgForm) {
    if (!suppliersForm.value.Id) {
      this.insertRecord(suppliersForm);
    } else {
      this.updateRecord(suppliersForm);
    }
    this.inEdit = false;
    this.service.formInEdit = false;
  }

  insertRecord(suppliersForm: NgForm) {
    this.service.postCurrentSupplier().subscribe(
      res => {
        this.service.refreshList();
      },
      err => {
        console.info(err);
      }
    )
  }

  updateRecord(suppliersForm: NgForm) {
    this.service.putCurrentSupplier().subscribe(
      res => {
        this.service.refreshList();
      },
      err => {
        console.info(err);
      }
    )
  }

  clearForm(form: any) {
    this.populateSupplirForm();
    form.resetForm();
    this.inEdit = false;
  }

}
