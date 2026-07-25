import { Component, inject } from '@angular/core';
import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Store } from '@ngrx/store';
import { selectEnrolledCourses } from '../../store/enrollment.selectors';
@Component({ selector: 'app-student-profile', imports: [AsyncPipe, NgFor, NgIf], template: '<h1>Student Profile</h1><section class="profile"><h2>Alex Morgan</h2><p>Computer Science · Semester 5</p><h3>My enrolled courses</h3><ul *ngIf="enrolledCourses$ | async as courses"><li *ngFor="let course of courses">{{ course.code }} — {{ course.name }}</li><li *ngIf="!courses.length">No courses enrolled yet. Browse the course catalog to get started.</li></ul></section>', styles: ['.profile { background:#fff; border:1px solid #dbeafe; border-radius:.75rem; padding:1.25rem; } li { margin:.5rem 0; }'] })
export class StudentProfileComponent { private readonly store = inject(Store); readonly enrolledCourses$ = this.store.select(selectEnrolledCourses); }
