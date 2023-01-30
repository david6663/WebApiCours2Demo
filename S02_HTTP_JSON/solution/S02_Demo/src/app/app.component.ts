import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//// VERSION A
// export class AppComponent {

//// VERSION B
export class AppComponent implements OnInit {
  title = 'S02_Demo';
 
  artist ?: string;
  album ?: string;
  image ?: string;

  constructor(public http : HttpClient){}

  //// VERSION A
  // request():void{
  //   this.http.get<any>("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=VOTRECLE&artist=Cher&album=Believe&format=json")
  //   .subscribe(x =>console.log(x));
  // }

  //// VERSION B
//   ngOnInit():void{
//   this.http.get<any>("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=VOTRECLE&artist=Cher&album=Believe&format=json")
//   .subscribe(x =>console.log(x));
// }

 //// VERSION c
 ngOnInit():void{
  this.http.get<any>("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=VOTRECLE&artist=Cher&album=Believe&format=json")
  .subscribe(x => {
    this.artist = x.album.artist;
    this.album = x.album.name;
    this.image = x.album.image[2]["#text"];
    });
  }
}
