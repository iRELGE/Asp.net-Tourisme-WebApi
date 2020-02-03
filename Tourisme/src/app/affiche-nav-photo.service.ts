import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AfficheNavPhotoService {

  constructor(private http: HttpClient) { }


  getAllSlide() {
    return this.http.get("http://localhost:51473/api/SliderPubPhoto");
  }
}
