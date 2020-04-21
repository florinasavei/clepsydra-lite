import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierProductCategoryFormComponent } from './supplier-product-category-form.component';

describe('SupplierProductCategoryFormComponent', () => {
  let component: SupplierProductCategoryFormComponent;
  let fixture: ComponentFixture<SupplierProductCategoryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplierProductCategoryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierProductCategoryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
