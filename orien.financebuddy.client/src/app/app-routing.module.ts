import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './shared/home/home.component';
import { DashboardComponent } from './shared/dashboard/dashboard.component';
import { LoginComponent } from './shared/login/login.component';
import { LoansComponent } from './shared/loans/loans.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full' // Ensure full match to prevent unwanted redirection loops
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '',
    component: HomeComponent, // Always present
    children: [
      {
        path: 'home', // Loads Dashboard inside HomeComponent
        component: DashboardComponent
      },
      {
        path: 'loans', // Loads LoansComponent inside HomeComponent
        component: LoansComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
