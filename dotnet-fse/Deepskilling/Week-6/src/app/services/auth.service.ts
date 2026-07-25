import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private loggedIn = false;
  get isLoggedIn(): boolean { return this.loggedIn; }
  toggleLogin(): void { this.loggedIn = !this.loggedIn; }
}
