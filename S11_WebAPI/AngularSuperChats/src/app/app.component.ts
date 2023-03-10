import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

class Cat {
  constructor(
    public id: number,
    public name: string
  ) { }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  catName: string = '';
  cats: Cat[] = [];

  constructor(public http: HttpClient) { }

  sendCat(){
    this.http.post<Cat>('https://localhost:7096/api/Cats', new Cat(0,this.catName)).subscribe(res => console.log(res));

    this.catName = '';
  }

  getCats() {
    this.http.get<Cat[]>('https://localhost:7096/api/Cats').subscribe(res => this.cats = res);
  }

}
