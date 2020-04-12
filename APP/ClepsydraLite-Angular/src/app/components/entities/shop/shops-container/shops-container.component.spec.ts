import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopsContainerComponent } from './shops-container.component';

describe('ShopsContainerComponent', () => {
  let component: ShopsContainerComponent;
  let fixture: ComponentFixture<ShopsContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShopsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShopsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
