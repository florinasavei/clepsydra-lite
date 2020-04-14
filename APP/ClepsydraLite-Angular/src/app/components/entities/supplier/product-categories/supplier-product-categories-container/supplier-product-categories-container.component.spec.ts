import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierProductCategoriesContainerComponent } from './supplier-product-categories-container.component';

describe('SupplierProductCategoriesContainerComponent', () => {
  let component: SupplierProductCategoriesContainerComponent;
  let fixture: ComponentFixture<SupplierProductCategoriesContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplierProductCategoriesContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierProductCategoriesContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
