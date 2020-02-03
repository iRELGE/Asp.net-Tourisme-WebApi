import { AuthentificationService } from './../../authentification.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userClaims: any;
  constructor(private authService: AuthentificationService) { }

  ngOnInit() {

  }

}
