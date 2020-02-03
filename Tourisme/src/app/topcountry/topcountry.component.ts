import { PostsAvisModule } from './../Models/posts-avis/posts-avis.module';
import { PostesService } from 'src/app/postes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-topcountry',
  templateUrl: './topcountry.component.html',
  styleUrls: ['./topcountry.component.css']
})
export class TopcountryComponent implements OnInit {

  constructor(private newHos: PostesService) { }
  country: PostsAvisModule[] = []

  ngOnInit() {
    this.getNewHostel()
  }
  getNewHostel() {
    this.newHos.getPostes(4, "best").subscribe((res: PostsAvisModule[]) => {

      this.country = res;
      console.log("Country")
      console.log(this.country)


    })
  }

}
