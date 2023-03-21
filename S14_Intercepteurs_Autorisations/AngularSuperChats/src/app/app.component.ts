import { HttpClient, HttpHeaders, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthenticationInterceptor } from 'src/authentication.interceptor';

class Cat {
  constructor(
    public id: number,
    public name: string,
    public villagerID:number
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

  loginUser(){
    let user={
      username:"Roland123",
      password:"Password!2345"
    }
    this.http.post<any>('https://localhost:7096/api/Users/Login', user);
  }

  registerUser(){
   let user = {
    username : "Roland123",
    email : "Roland@boomer.ca",
    password : "Password!2345",
    passwordConfirm : "Password!2345",
    nickName:"blablabla"
   };
   
    this.http.post<any>('https://localhost:7096/api/Users', user).subscribe(x => { console.log(x);
    localStorage.setItem("authToken", x.token);
    });
  }

  getVillagers() {
    // let token = localStorage.getItem("authToken");
    // let httpOptions = {
    //   headers : new HttpHeaders({
    //     'ContentType' : 'application/json',
    //     'Authorization' : 'Bearer' + token
    //   })
    // };

    this.http.get<Villager[]>('https://localhost:7096/api/Villagers/GetVillager').subscribe(res => 
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
    this.http.post<Cat>('https://localhost:7096/api/Cats/PostCat', new Cat(0,this.catName,1) ).subscribe(res => console.log(res));

    this.catName = '';
  }

  getCats() {
    this.http.get<Cat[]>('https://localhost:7096/api/Cats/GetCats').subscribe(res => {
    console.log(res);  
    this.cats = res;
  });
  }

}
