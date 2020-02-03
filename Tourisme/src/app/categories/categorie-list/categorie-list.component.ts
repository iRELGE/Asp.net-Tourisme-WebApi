import { CategoriesService } from './../../categories.service';
import { CategorieModule } from './../../Models/categorie/categorie.module';
import { AuthentificationService } from './../../authentification.service';
import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';

@Component({
  selector: 'app-categorie-list',
  templateUrl: './categorie-list.component.html',
  styleUrls: ['./categorie-list.component.css']
})
export class CategorieListComponent implements OnInit {
  userClaims: any;
  listCategorie: CategorieModule[] = []
  constructor(private authService: AuthentificationService, private catService: CategoriesService) { }

  ngOnInit() {
    this.getAllArticles();
    this.authService.getUserClaims().subscribe((data: any) => {
      this.userClaims = data;
      console.log(this.userClaims);

    });
  }
  getAllArticles() {
    this.catService.getCategories()
      .subscribe((res: CategorieModule[]) => {
        this.listCategorie = res;
        console.log(res);
      })



  }

}
