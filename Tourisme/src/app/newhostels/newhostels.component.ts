import { NewHostelsModule } from './../Models/new-hostels/new-hostels.module';
import { PostesService } from 'src/app/postes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-newhostels',
  templateUrl: './newhostels.component.html',
  styleUrls: ['./newhostels.component.css']
})
export class NewhostelsComponent implements OnInit {

  constructor(private newHos: PostesService) { }
  imgUrl = "./assets/img/default.png"
  newh: NewHostelsModule[] = []


  ngOnInit() {
    this.getNewHostel()
  }
  getNewHostel() {
    this.newHos.getPostes(4, "date").subscribe((res: NewHostelsModule[]) => {

      this.newh = res;
      console.log("new hostels")
      console.log(this.newh)


    })
  }

}
