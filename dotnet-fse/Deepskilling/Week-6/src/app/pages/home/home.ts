import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { selectAllCourses } from '../../store/course.selectors';
import { selectEnrolledIds } from '../../store/enrollment.selectors';
import { loadCourses } from '../../store/course.actions';

@Component({ selector: 'app-home', imports: [FormsModule], templateUrl: './home.html', styleUrl: './home.css' })
export class HomeComponent implements OnInit, OnDestroy {
  portalName = 'Student Course Portal'; isPortalActive = true; message = ''; searchTerm = ''; availableCourses = 0; enrolledCount = 0;
  constructor(private readonly store: Store, private readonly router: Router) {}
  ngOnInit(): void { this.store.dispatch(loadCourses()); this.store.select(selectAllCourses).subscribe((courses) => this.availableCourses = courses.length); this.store.select(selectEnrolledIds).subscribe((ids) => this.enrolledCount = ids.length); }
  ngOnDestroy(): void { console.log('HomeComponent destroyed'); }
  onEnrollClick(): void { this.router.navigate(['/enroll']); }
  search(): void { this.router.navigate(['/courses'], { queryParams: this.searchTerm ? { search: this.searchTerm } : {} }); }
}
