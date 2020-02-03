import { RouterModule, Router } from '@angular/router';
import { AuthentificationService } from './../../authentification.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  imageUrl: string = "/assets/img/default-image.png"
  fileToUpload: File = null;
  register = new FormGroup(
    {
      email: new FormControl(""),
      password: new FormControl(""),
      confirmpassword: new FormControl(""),
      Name: new FormControl(""),
      lastName: new FormControl(""),



    }
  )

  constructor(private authService: AuthentificationService, private router: Router) { }

  ngOnInit() {
  }
  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }
  SignUp() {
    console.log(this.register);
    //console.log(Caption, Image);


    this.authService.Register(this.register.value).subscribe(() => {

      this.router.navigateByUrl('/Login')
    })



  }

}
