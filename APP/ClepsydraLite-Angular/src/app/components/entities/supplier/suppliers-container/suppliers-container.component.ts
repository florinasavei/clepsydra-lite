import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/entities/supplier/supplier.service';

@Component({
  selector: 'app-suppliers-container',
  templateUrl: './suppliers-container.component.html',
  styleUrls: ['./suppliers-container.component.scss']
})
export class SuppliersContainerComponent implements OnInit {

  constructor(public service: SupplierService) { }

  ngOnInit(): void {
    this.service.formInEdit = false;
  }
  
  toggleForm = function(){
    this.service.formInEdit = !this.service.formInEdit;
  };

}
