import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { VehicleRentalContextService, VehicleRentalContext } from '../shared/services/vehicle-rental-context.service';

@Component({
  selector: 'app-vehicle-rental-layout',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './vehicle-rental-layout.component.html',
  styleUrl: './vehicle-rental-layout.component.scss',})
export class VehicleRentalLayoutComponent implements OnInit {
  context: VehicleRentalContext | null = null;
  
  private contextService = inject(VehicleRentalContextService);
  private router = inject(Router);

  ngOnInit() {
    this.contextService.loadContext();
    this.contextService.context$.subscribe(ctx => {
      this.context = ctx;
    });
  }
}
