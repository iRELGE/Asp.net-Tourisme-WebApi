import { AuthGuard } from './auth.guard';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './partager/navbar/navbar.component';
import { CategoriePostComponent } from './categories/categorie-post/categorie-post.component';
import { CategorieEditComponent } from './categories/categorie-edit/categorie-edit.component';
import { CategorieListComponent } from './categories/categorie-list/categorie-list.component';
import { RegisterComponent } from './Register/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './Login/login/login.component';
import { AuthentificationService } from './authentification.service';
import { NavbarAddPhotoComponent } from './navbar/navbar-add-photo/navbar-add-photo.component';
import { NavbarListPhotoComponent } from './navbar/navbar-list-photo/navbar-list-photo.component';
import { PostsBestActivitiesComponent } from './posts/posts-best-activities/posts-best-activities.component';
import { PostsBestPlaceToTravelComponent } from './posts/posts-best-place-to-travel/posts-best-place-to-travel.component';
import { RatingModule } from 'ng-starrating';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SliderModule } from './slider/slider.module';
import { NewhostelsComponent } from './newhostels/newhostels.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { TopcountryComponent } from './topcountry/topcountry.component';
import { AddPostComponent } from './posts/add-post/add-post.component';
import { ItemsComponent } from './items/items.component';
import { PosteDetailComponent } from './poste-detail/poste-detail.component';
import { FooterComponent } from './partager/footer/footer.component';
import { DashboardHomeComponent } from './UserDashboard/dashboard-home/dashboard-home.component';
import { BlogPostComponent } from './UserDashboard/blog-post/blog-post.component';
import { AddNewPostComponent } from './UserDashboard/add-new-post/add-new-post.component';




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoriePostComponent,
    CategorieEditComponent,
    CategorieListComponent,
    RegisterComponent,
    LoginComponent,
    NavbarAddPhotoComponent,
    NavbarListPhotoComponent,
    PostsBestActivitiesComponent,
    PostsBestPlaceToTravelComponent,
    NewhostelsComponent,
    FeedbackComponent,
    TopcountryComponent,
    AddPostComponent,
    ItemsComponent,
    PosteDetailComponent,
    FooterComponent,
    DashboardHomeComponent,
    BlogPostComponent,
    AddNewPostComponent,

  ],
  imports: [
    BrowserModule,
    RatingModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    SliderModule
  ],
  providers: [AuthentificationService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
