import { PostsAvisModule } from './../Models/posts-avis/posts-avis.module';
import { PostesService } from 'src/app/postes.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-poste-detail',
  templateUrl: './poste-detail.component.html',
  styleUrls: ['./poste-detail.component.css']
})
export class PosteDetailComponent implements OnInit {
  id: string = "";
  post: PostsAvisModule
  title: string
  image: string
  description: string
  nombreAvis: number
  Client_image: string
  Client_Prenom: string
  constructor(private route: ActivatedRoute, private getOnePost: PostesService) { }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.onePost()
  }
  onePost() {
    this.getOnePost.getOnePost(this.id).subscribe((res: PostsAvisModule) => {
      this.title = res.Poste_title
      this.description = res.Poste_description
      this.image = res.Poste_image

      this.nombreAvis = res.nombreAvis
      this.Client_Prenom = res.Client_Prenom
      this.Client_image = res.Client_image


    })

  }

}
