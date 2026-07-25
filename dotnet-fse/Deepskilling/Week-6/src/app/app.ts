import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header';
import { AsyncPipe, NgIf } from '@angular/common';
import { LoadingService } from './services/loading.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, AsyncPipe, NgIf],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App { constructor(readonly loading: LoadingService) {} }
