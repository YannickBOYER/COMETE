import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'upload', loadComponent: () => import('../pages/upload-page/upload-page.component').then(m => m.UploadPageComponent) },
  { path: 'profil', loadComponent: () => import('../pages/profil-page/profil-page.component').then(m => m.ProfilPageComponent) },
  { path: 'gestion-comptes', loadComponent: () => import('../pages/gestion-comptes-page/gestion-comptes-page.component').then(m => m.GestionComptesPageComponent) },
  { path: '', redirectTo: '/profil', pathMatch: 'full' },
  { path: '**', redirectTo: '/profil' }
];
