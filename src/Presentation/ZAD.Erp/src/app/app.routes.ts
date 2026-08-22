import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'account/login/company', pathMatch: 'full' },
  {
    path: 'account/login/company',
    loadComponent: () => import('./features/vehicle-rental/login/vehicle-rental-login.component').then(m => m.VehicleRentalLoginComponent)
  },
  {
    path: '',
    loadComponent: () => import('./core/layout/main-layout.component').then(m => m.MainLayoutComponent),
    children: [
      { path: 'dashboard', loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent) },
      {
        path: 'vehicle-rental',
        loadComponent: () => import('./features/vehicle-rental/layout/vehicle-rental-layout.component').then(m => m.VehicleRentalLayoutComponent),
        children: [
          { path: '', redirectTo: 'contracts', pathMatch: 'full' },
          {
            path: 'contracts',
            loadComponent: () => import('./features/vehicle-rental/contracts/components/contracts/contracts.component').then(m => m.ContractsComponent)
          },
          {
            path: 'contracts/add',
            loadComponent: () => import('./features/vehicle-rental/contracts/components/add-contract/add-contract.component').then(m => m.AddContractComponent)
          },
          {
            path: 'contracts/edit/:id',
            loadComponent: () => import('./features/vehicle-rental/contracts/components/add-contract/add-contract.component').then(m => m.AddContractComponent)
          }
        ]
      },
      {
        path: 'settings',
        loadComponent: () => import('./features/settings/layout/settings-layout.component').then(m => m.SettingsLayoutComponent),
        children: [
          { path: '', redirectTo: 'companies', pathMatch: 'full' },
          {
            path: 'companies',
            loadComponent: () => import('./features/companies/components/company-list/company-list.component').then(m => m.CompanyListComponent)
          },
          {
            path: 'companies/add',
            loadComponent: () => import('./features/companies/components/company-form/company-form.component').then(m => m.CompanyFormComponent)
          },
          {
            path: 'companies/edit/:id',
            loadComponent: () => import('./features/companies/components/company-form/company-form.component').then(m => m.CompanyFormComponent)
          },
          {
            path: 'companies/view/:id',
            loadComponent: () => import('./features/companies/components/company-view/company-view.component').then(m => m.CompanyViewComponent)
          },
          {
            path: 'branches',
            loadComponent: () => import('./features/branches/components/branch-list/branch-list.component').then(m => m.BranchListComponent)
          },
          {
            path: 'branches/add',
            loadComponent: () => import('./features/branches/components/branch-form/branch-form.component').then(m => m.BranchFormComponent)
          },
          {
            path: 'branches/edit/:id',
            loadComponent: () => import('./features/branches/components/branch-form/branch-form.component').then(m => m.BranchFormComponent)
          },
          {
            path: 'branches/view/:id',
            loadComponent: () => import('./features/branches/components/branch-view/branch-view.component').then(m => m.BranchViewComponent)
          }
        ]
      }
    ]
  },
  { path: '**', redirectTo: 'account/login/company' }
];
