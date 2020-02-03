import { PostsAvisModule } from './../../Models/posts-avis/posts-avis.module';
import { PostesService } from 'src/app/postes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.css']
})
export class BlogPostComponent implements OnInit {
  postbyFeedBack: PostsAvisModule[] = []


  constructor(private allp: PostesService) { }

  ngOnInit() {
    this.getallpostesByFeedBack()
  }
  getallpostesByFeedBack() {
    this.allp.getPostes(4, "best").subscribe((res: PostsAvisModule[]) => {

      this.postbyFeedBack = res
      console.log(this.postbyFeedBack)
    })
  }

}
