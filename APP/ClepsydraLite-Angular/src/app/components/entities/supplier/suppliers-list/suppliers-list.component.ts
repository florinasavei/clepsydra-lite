import { Component, OnInit } from '@angular/core';
import { SupplierService } from '../../../../services/entities/supplier/supplier.service';


@Component({
  selector: 'app-suppliers-list',
  templateUrl: './suppliers-list.component.html',
  styleUrls: ['./suppliers-list.component.scss']
})
export class SuppliersListComponent implements OnInit {

  constructor(private service: SupplierService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

}
