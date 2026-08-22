import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationCheckboxRenderer } from './operation-checkbox.renderer';

describe('OperationCheckboxRenderer', () => {
  let component: OperationCheckboxRenderer;
  let fixture: ComponentFixture<OperationCheckboxRenderer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperationCheckboxRenderer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationCheckboxRenderer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
