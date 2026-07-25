import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {
  message = '';
  show(message: string): void { this.message = message; }
}
