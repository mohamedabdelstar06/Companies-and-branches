import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationHeaderRenderer } from './operation-header.renderer';

describe('OperationHeaderRenderer', () => {
  let component: OperationHeaderRenderer;
  let fixture: ComponentFixture<OperationHeaderRenderer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperationHeaderRenderer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationHeaderRenderer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
