import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const errorHandlerInterceptor: HttpInterceptorFn = (req, next) => next(req).pipe(catchError((error: HttpErrorResponse) => {
  if (error.status === 401) inject(Router).navigateByUrl('/');
  return throwError(() => error);
}));
