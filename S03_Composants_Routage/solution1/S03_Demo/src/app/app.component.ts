import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

  // // VERSION A
    export class AppComponent implements OnInit {
      title = 'S02_Demo';
      artist ?: string;
      album ?: string;
      image ?: string;

  constructor(public http : HttpClient){}
  
  // // VERSION A
      ngOnInit():void{
        this.http.get<any>("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=63a87ada7b7a5d9dc0e99cb820a426cc&artist=Cher&album=Believe&format=json")
        .subscribe(x => {
          this.artist = x.album.artist;
          this.album = x.album.name;
          this.image = x.album.image[2]["#text"];
          }
        );
    
  }

}
