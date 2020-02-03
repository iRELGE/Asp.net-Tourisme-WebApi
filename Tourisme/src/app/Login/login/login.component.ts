import { TokenParamsModule } from './../../Models/token-params/token-params.module';
import { Router } from '@angular/router';
import { AuthentificationService } from './../../authentification.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit, ɵConsole } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userData = new FormGroup(
    {
      email: new FormControl(""),
      password: new FormControl(""),

    })
  isLoginError: boolean = false;
  userClaims: TokenParamsModule

  constructor(private authService: AuthentificationService, private router: Router) { }

  ngOnInit() {
  }
  loged() {
    var e = this.userData.controls.email.value;
    var p = this.userData.controls.password.value;
    // console.log(e, p);
    this.authService.Login(e, p).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      console.log("loged");

      this.claimInfo()
    },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
      });
  }

  claimInfo() {
    this.authService.getUserClaims().subscribe((data: TokenParamsModule) => {
      this.userClaims = data;
      localStorage.setItem('userId', this.userClaims.ID)
      localStorage.setItem('userName', this.userClaims.Client_Nom);
      localStorage.setItem('userLastName', this.userClaims.Client_Prenom);
      localStorage.setItem('userPhoto', this.userClaims.Client_image);
      localStorage.setItem('Age', this.userClaims.Client_age);
      localStorage.setItem('userAdress', this.userClaims.Client_adresse);
      localStorage.setItem('email', this.userClaims.Email);
      console.log(this.userClaims)




      this.router.navigateByUrl("UserDashboard");


    });
  }

}
