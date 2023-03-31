import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

class Cat {
  constructor(
    public id: number,
    public name: string
  ) { }
}

class Villager {
  constructor(
    public id: number,
    public name: string,
    public job: string,
    public zombified: boolean
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
  villagers: Villager[] = [];
  villager: any;

  constructor(public http: HttpClient) { }

  registerUser(){
   let user = {
    username : "Roland123",
    email : "Roland@boomer.ca",
    password : "Password!2345",
    passwordConfirm : "Password!2345"
   };

    this.http.post<any>('https://localhost:7096/api/Users', user).subscribe(x => { console.log(x);
    localStorage.setItem("authToken", x.token);
    });
  }

  getVillagers() {
    let token = localStorage.getItem("authToken");
    let httpOptions = {
      headers : new HttpHeaders({
        'ContentType' : 'application/json',
        'Authorization' : 'Bearer' + token
      })
    };

    this.http.get<Villager[]>('https://localhost:7096/api/Villagers/GetVillager', httpOptions).subscribe(res =>
    {
      console.log(res);
      this.villagers = res;
    });
  }

  saveVillager() {
    let token = localStorage.getItem("authToken");
    let httpOptions = {
      headers : new HttpHeaders({
        'ContentType' : 'application/json',
        'Authorization' : 'Bearer' + token
      })
    };

    this.http.post<Villager>("https://localhost:7096/api/Villagers/PostVillager", this.villager, httpOptions).subscribe(res =>
    {
      console.log(res);
    })
  }



  sendCat(){
    this.http.post<Cat>('https://localhost:7096/api/Cats/PutCat', new Cat(0,this.catName)).subscribe(res => console.log(res));

    this.catName = '';
  }

  getCats() {
    this.http.get<Cat[]>('https://localhost:7096/api/Cats').subscribe(res => {console.log(res);this.cats = res});
  }


  /////////////////////////////////////////////
  /////pour la version avec typescript
  uploadPicture(file?:File):void{
    if(file!=null && file!=undefined)
    {let formData=new FormData();
    formData.append('file', file, file.name);

    this.http.post<any>("https://localhost:7096/api/pictures", formData).subscribe(x=>{console.log(x);})}
  }
}
