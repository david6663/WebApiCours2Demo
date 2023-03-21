import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    console.log("J'ai réussi l'interception!!!");

    if(request.url!="https://localhost:7096/api/Users/Register"){

      request=request.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer '+ localStorage.getItem("authKey")
        }
      })

      let url:URL=new URL(request.url);
      console.log(url);

    }

    return next.handle(request);
  }
}
