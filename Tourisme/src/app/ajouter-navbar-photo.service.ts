import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AjouterNavbarPhotoService {

  constructor(private http: HttpClient) { }

  postFile(caption: string, fileToUpload: File) {
    console.log('ok2');
    const endpoint = 'http://localhost:51473/api/PublicitNavBars';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('ImageCaption', caption);
    return this.http
      .post(endpoint, formData);
  }
  getAllSlide() {
    this.http.get("http://localhost:51473/api/");
  }
}
