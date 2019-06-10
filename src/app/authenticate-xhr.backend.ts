import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/internal/operators';
import { Router } from '@angular/router';


// sweet global way to handle 401s - works in tandem with existing AuthGuard route checks
// http://stackoverflow.com/questions/34934009/handling-401s-globally-with-angular-2

@Injectable()
export class AuthenticateXHRBackend implements  HttpInterceptor  {

    constructor(private router: Router) {
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
          .pipe(
            catchError((err, caught: Observable<HttpEvent<any>>) => {
              if ((err.status === 401 || err.status === 403) && (window.location.href.match(/\?/g) || []).length < 2) {
                localStorage.removeItem('auth_token');
                this.router.navigate(['account/facebook-login']);
                return of(err as any);
              }
              throw err;
            })
          );
      }
}