import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BestActivitiesService {

  constructor(private http: HttpClient) { }

  getAllActivities() {
    return this.http.get("http://localhost:51473/api/lesMeilleursActivites");
  }
}
