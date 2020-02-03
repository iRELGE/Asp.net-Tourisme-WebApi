import { SlideShowModule } from './../../Models/slide-show/slide-show.module';
import { AfficheNavPhotoService } from './../../affiche-nav-photo.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar-list-photo',
  templateUrl: './navbar-list-photo.component.html',
  styleUrls: ['./navbar-list-photo.component.css']
})
export class NavbarListPhotoComponent implements OnInit {
  listSlide: SlideShowModule[] = []

  constructor(private afchPhoto: AfficheNavPhotoService) { }


  ngOnInit() {
    this.getAll();

  }

  getAll() {
    this.afchPhoto.getAllSlide().subscribe((res: SlideShowModule[]) => {
      this.listSlide = res;
      console.log(this.listSlide);

    })
  }

}
