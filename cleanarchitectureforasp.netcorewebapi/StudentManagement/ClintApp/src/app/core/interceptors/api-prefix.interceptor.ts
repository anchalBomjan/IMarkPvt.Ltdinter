import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';


@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const apiReq = request.clone({
      url: environment.apiBaseUrl + request.url
    });
    return next.handle(apiReq);
  }
}