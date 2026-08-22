import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  styles: [`
    .dashboard-bg { 
      background: linear-gradient(135deg, #e3f2fd 0%, #bbdefb 100%); 
      min-height: calc(100vh - 120px); 
    }
    .cursor-pointer { cursor: pointer; }
    .module-card {
      transition: transform 0.2s, box-shadow 0.2s;
    }
    .module-card:hover {
      transform: translateY(-5px);
      box-shadow: 0 .5rem 1rem rgba(0,0,0,.15)!important;
    }
  `]
})
export class DashboardComponent {
  modules = [
    { title: 'Settings', icon: 'fas fa-cogs', color: '#176B6B', route: '/settings/companies' },
    { title: 'Vehicle Rental', icon: 'fas fa-car', color: '#176B6B', route: '/vehicle-rental' }
  ];
}
