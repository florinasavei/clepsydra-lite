import { Component, OnInit } from '@angular/core';
import { SupplierService } from '../../../../services/entities/supplier/supplier.service';

@Component({
  selector: 'app-suppliers-container',
  templateUrl: './suppliers-container.component.html',
  styleUrls: ['./suppliers-container.component.scss']
})
export class SuppliersContainerComponent implements OnInit {

  constructor(private service: SupplierService) { }

  ngOnInit(): void {
  }

}
