import { TestBed } from '@angular/core/testing';

import { SupplierProductCategoriesService } from './supplier-product-categories.service';

describe('SupplierProductCategoriesService', () => {
  let service: SupplierProductCategoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SupplierProductCategoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
