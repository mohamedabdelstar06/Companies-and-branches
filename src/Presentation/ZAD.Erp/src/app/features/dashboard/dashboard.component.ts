import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  modules = [
    { title: 'Settings', icon: 'fas fa-cogs', color: '#176B6B', route: '/settings/companies' },
    { title: 'Vehicle Rental', icon: 'fas fa-car', color: '#176B6B', route: '/vehicle-rental' }
  ];
}
