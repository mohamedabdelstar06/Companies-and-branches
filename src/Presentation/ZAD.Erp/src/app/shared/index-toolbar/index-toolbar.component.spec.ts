import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexToolbarComponent } from './index-toolbar.component';

describe('IndexToolbarComponent', () => {
  let component: IndexToolbarComponent;
  let fixture: ComponentFixture<IndexToolbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndexToolbarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndexToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
