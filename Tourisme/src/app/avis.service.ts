import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AvisService {

  constructor(private http: HttpClient) { }

  getAvis() {
    return this.http.get("http://localhost:51473/api/listTroisavissRandom");
  }
}
