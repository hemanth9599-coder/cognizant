import { Component, inject, OnInit } from '@angular/core';
import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { combineLatest, map } from 'rxjs';
import { CourseCardComponent } from '../../components/course-card/course-card';
import { HighlightDirective } from '../../directives/highlight.directive';
import { Course } from '../../models/course.model';
import { loadCourses } from '../../store/course.actions';
import { selectAllCourses, selectCoursesError, selectCoursesLoading } from '../../store/course.selectors';
import { enrollInCourse, unenrollFromCourse } from '../../store/enrollment.actions';
import { selectEnrolledIds } from '../../store/enrollment.selectors';

@Component({ selector: 'app-course-list', imports: [AsyncPipe, NgFor, NgIf, CourseCardComponent, HighlightDirective], templateUrl: './course-list.html', styleUrl: './course-list.css' })
export class CourseListComponent implements OnInit {
  private readonly store = inject(Store);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);
  readonly loading$ = this.store.select(selectCoursesLoading);
  readonly error$ = this.store.select(selectCoursesError);
  readonly enrolledIds$ = this.store.select(selectEnrolledIds);
  readonly courses$ = combineLatest([this.store.select(selectAllCourses), this.route.queryParamMap]).pipe(map(([courses, params]) => {
    const search = (params.get('search') || '').toLowerCase();
    return search ? courses.filter((course) => `${course.name} ${course.code}`.toLowerCase().includes(search)) : courses;
  }));
  selectedCourseId: number | null = null;
  ngOnInit(): void { this.store.dispatch(loadCourses()); }
  trackByCourseId(_: number, course: Course): number { return course.id; }
  onEnroll(courseId: number, enrolled: boolean): void { this.selectedCourseId = courseId; this.store.dispatch(enrolled ? unenrollFromCourse({ courseId }) : enrollInCourse({ courseId })); }
  openCourse(courseId: number): void { this.router.navigate(['courses', courseId]); }
}
