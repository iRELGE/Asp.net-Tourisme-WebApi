import { AvisHomeModule } from './../Models/avis-home/avis-home.module';
import { AvisService } from './../avis.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  avis: AvisHomeModule[] = []

  constructor(private as: AvisService) { }

  ngOnInit() {
    this.ShowAvis();
  }
  ShowAvis() {
    this.as.getAvis().subscribe((res: AvisHomeModule[]) => {
      this.avis = res
    })
  }

}
