import 'rxjs/add/operator/do';
import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs/Observable';

//export class JwtInterceptor implements HttpInterceptor {
//  constructor(public auth: AuthService) {}
  //intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
//     return next.handle(req).do((event: HttpEvent<any>) => {
//       if (event instanceof HttpResponse) {
//         // do stuff with response if you want
//       }
//     }, (err: any) => {
//       if (err instanceof HttpErrorResponse) {
//         if (err.status === 401) {
//           // redirect to the login route
//           // or show a modal
//         }
//       }
//     });
//   }
//}