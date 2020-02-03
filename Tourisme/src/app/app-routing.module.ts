import { AddNewPostComponent } from './UserDashboard/add-new-post/add-new-post.component';
import { BlogPostComponent } from './UserDashboard/blog-post/blog-post.component';
import { DashboardHomeComponent } from './UserDashboard/dashboard-home/dashboard-home.component';
import { PosteDetailComponent } from './poste-detail/poste-detail.component';
import { PostsBestPlaceToTravelComponent } from './posts/posts-best-place-to-travel/posts-best-place-to-travel.component';
import { LoginComponent } from './Login/login/login.component';
import { CategorieListComponent } from './categories/categorie-list/categorie-list.component';
import { RegisterComponent } from './Register/register/register.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';


const routes: Routes = [
  { path: "", component: CategorieListComponent },
  { path: "Home", component: CategorieListComponent },
  { path: "Register", component: RegisterComponent },
  { path: "Login", component: LoginComponent },
  { path: "Posts", component: PostsBestPlaceToTravelComponent },
  { path: ":id/DetailPost", component: PosteDetailComponent },


  {
    path: "UserDashboard", children: [
      { path: "", component: DashboardHomeComponent },

      { path: "AllPosts", component: BlogPostComponent },
      { path: "AddNewPost", component: AddNewPostComponent },]
  }





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
