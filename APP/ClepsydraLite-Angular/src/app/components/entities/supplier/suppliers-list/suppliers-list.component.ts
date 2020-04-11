import { Component, OnInit } from '@angular/core';
import { SupplierService } from '../../../../services/entities/supplier/supplier.service';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';

@Component({
  selector: 'app-suppliers-list',
  templateUrl: './suppliers-list.component.html',
  styleUrls: ['./suppliers-list.component.scss']
})
export class SuppliersListComponent implements OnInit {

  constructor(public service: SupplierService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(sup:Supplier){
    this.service.suppliersFormData =  Object.assign({}, sup);
  }

  onDelete(id){
    if(confirm("Are you sure you want to delete?"))
    this.service.deleteSupplier(id)
    .subscribe(res => {
      this.service.refreshList();
    },
      err=>{
        console.info(err)
      })
  }

}
