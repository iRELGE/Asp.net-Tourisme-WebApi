import { AjouterNavbarPhotoService } from './../../ajouter-navbar-photo.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar-add-photo',
  templateUrl: './navbar-add-photo.component.html',
  styleUrls: ['./navbar-add-photo.component.css']
})
export class NavbarAddPhotoComponent implements OnInit {

  imageUrl: string = "/assets/img/default-image.png";
  fileToUpload: File = null;
  constructor(private imageService: AjouterNavbarPhotoService) { }

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

  OnSubmit(Caption, Image) {
    console.log('ok');
    this.imageService.postFile(Caption.value, this.fileToUpload).subscribe(
      data => {
        console.log('done');
        Caption.value = null;
        Image.value = null;
        this.imageUrl = "/assets/img/default-image.png";
      }
    );
  }

}
