import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { NotificationService } from '../../services/notification.service';
@Component({ selector: 'app-notification', imports: [NgIf], providers: [NotificationService], template: '<p *ngIf="notifications.message" class="notice">{{ notifications.message }}</p>', styles: ['.notice { background:#eff6ff; color:#1e40af; padding:.75rem; border-radius:.5rem; }'] })
export class NotificationComponent { // This provider creates a separate NotificationService instance scoped to this component.
  constructor(readonly notifications: NotificationService) {}
}
