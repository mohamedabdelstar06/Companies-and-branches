import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvatarCellComponent } from './avatar-cell.component';

describe('AvatarCellComponent', () => {
  let component: AvatarCellComponent;
  let fixture: ComponentFixture<AvatarCellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AvatarCellComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvatarCellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
