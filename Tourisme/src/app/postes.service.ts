import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PostesService {

  constructor(private http: HttpClient) { }

  getPostes(prend, option) {
    console.log("http://localhost:51473/api/account/register?prend=6&random=yes")
    return this.http.get(`http://localhost:51473/api/choioptionLimits/${prend}/${option}`);
    // http://localhost:51473/api/account/register?prend=6&random=yes

  }
  getOnePost(id) {
    return this.http.get(`http://localhost:51473/api/AfficherUnPost/${id}`);

  }
  getUserPosts(id) {

    return this.http.get(`http://localhost:51473/api/AllUserPostsInfo/${id}`);

  }
  DeletePostesAuth(id) {

    return this.http.delete(`http://localhost:51473/api/DeletePost/${id}`);

  }


}
