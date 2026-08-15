import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'settings/companies', pathMatch: 'full' },
  {
    path: 'settings/companies',
    loadComponent: () => import('./features/companies/components/company-list/company-list.component').then(m => m.CompanyListComponent)
  },
  {
    path: 'settings/companies/add',
    loadComponent: () => import('./features/companies/components/company-form/company-form.component').then(m => m.CompanyFormComponent)
  },
  {
    path: 'settings/companies/edit/:id',
    loadComponent: () => import('./features/companies/components/company-form/company-form.component').then(m => m.CompanyFormComponent)
  },
  {
    path: 'settings/companies/view/:id',
    loadComponent: () => import('./features/companies/components/company-view/company-view.component').then(m => m.CompanyViewComponent)
  },
  {
    path: 'settings/branches',
    loadComponent: () => import('./features/branches/components/branch-list/branch-list.component').then(m => m.BranchListComponent)
  },
  {
    path: 'settings/branches/add',
    loadComponent: () => import('./features/branches/components/branch-form/branch-form.component').then(m => m.BranchFormComponent)
  },
  {
    path: 'settings/branches/edit/:id',
    loadComponent: () => import('./features/branches/components/branch-form/branch-form.component').then(m => m.BranchFormComponent)
  },
  {
    path: 'settings/branches/view/:id',
    loadComponent: () => import('./features/branches/components/branch-view/branch-view.component').then(m => m.BranchViewComponent)
  }
];
