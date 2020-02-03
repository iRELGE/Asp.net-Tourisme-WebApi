
import { Router } from '@angular/router';
import { AllPostsUserInfoModule } from './../../Models/all-posts-user-info/all-posts-user-info.module';
import { PostsUserModule } from './../../Models/posts-user/posts-user.module';
import { PostesService } from 'src/app/postes.service';
import { Component, OnInit } from '@angular/core';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.css']
})
export class DashboardHomeComponent implements OnInit {

  postsUser: AllPostsUserInfoModule
  constructor(private up: PostesService, private router: Router) { }
  ID: string = localStorage.getItem('userId')
  name: string = localStorage.getItem('userName')
  lastName: string = localStorage.getItem('userLastName')
  image: string = localStorage.getItem('userPhoto')
  email: string = localStorage.getItem('email')
  adress: string = localStorage.getItem('userAdress')
  age: string = localStorage.getItem('Age')

  ngOnInit() {
    this.getUserPostsInfo()
    console.log("mu ID")
    console.log(this.ID)
  }
  getUserPostsInfo() {


    this.up.getUserPosts(this.ID).subscribe((res: AllPostsUserInfoModule) => {
      this.postsUser = res;
      console.log("post user")
      console.log(this.postsUser)

    })

  }


  deletePosts(id) {
    this.up.DeletePostesAuth(id).subscribe(() => { })
    console.log(id);


  }
  Logout() {

    localStorage.removeItem('userToken');
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
    localStorage.removeItem('userLastName');
    localStorage.removeItem('userPhoto');
    localStorage.removeItem('Age');
    localStorage.removeItem('userAdress');
    localStorage.removeItem('email');
    this.router.navigate(['/Login']);
  }

}
