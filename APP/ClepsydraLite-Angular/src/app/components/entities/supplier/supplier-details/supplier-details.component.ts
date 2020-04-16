import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/entities/supplier/supplier.service';
import { Supplier } from 'src/app/models/entities/supplier/supplier.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styles: [
  ]
})
export class SupplierDetailsComponent implements OnInit {

  constructor(public service: SupplierService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.supplierId = params.get("id")
    })
    this.service.getById(this.supplierId);
    this.currentSupplier = this.service.currentSupplier;
  }

  currentSupplier:Supplier = this.service.currentSupplier;
  supplierId;

}
