import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonDirectoryComponent } from './person-directory/person-directory.component';
import { PersonDetailsComponent } from './person-details/person-details.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, title: "Home - ACTS" },
  { path: 'directory', component: PersonDirectoryComponent, title: "Directory" },
  { path: 'people/:name', component: PersonDetailsComponent, title: "Person Details"},
  { path: '', redirectTo: '/home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
