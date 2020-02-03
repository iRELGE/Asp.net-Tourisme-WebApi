import { PostsAvisModule } from './../../Models/posts-avis/posts-avis.module';
import { Component, OnInit } from '@angular/core';
import { PostesService } from 'src/app/postes.service';

@Component({
  selector: 'app-posts-best-place-to-travel',
  templateUrl: './posts-best-place-to-travel.component.html',
  styleUrls: ['./posts-best-place-to-travel.component.css']
})
export class PostsBestPlaceToTravelComponent implements OnInit {
  allPosts: PostsAvisModule

  constructor(private postserve: PostesService) { }

  ngOnInit() {
    this.getAllPostesBYInfo()
  }
  getAllPostesBYInfo() {
    this.postserve.getPostes(4, "best").subscribe((res: PostsAvisModule) => {
      this.allPosts = res
      console.log(this.allPosts)
    })
  }

}
