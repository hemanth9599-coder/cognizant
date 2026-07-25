import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
@Component({ selector: 'app-not-found', imports: [RouterLink], template: '<section><p class="eyebrow">404</p><h1>Page not found</h1><p>The page you requested is unavailable.</p><a routerLink="/">Return to dashboard</a></section>', styles: ['.eyebrow { color:#2563eb; font-weight:700; } a { color:#1d4ed8; }'] })
export class NotFoundComponent {}
