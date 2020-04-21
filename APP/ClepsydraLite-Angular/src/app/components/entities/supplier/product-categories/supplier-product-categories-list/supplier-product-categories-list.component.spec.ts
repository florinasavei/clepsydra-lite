import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierProductCategoriesListComponent } from './supplier-product-categories-list.component';

describe('SupplierProductCategoriesListComponent', () => {
  let component: SupplierProductCategoriesListComponent;
  let fixture: ComponentFixture<SupplierProductCategoriesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplierProductCategoriesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierProductCategoriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
