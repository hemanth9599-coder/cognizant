import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { CourseCardComponent } from '../../components/course-card/course-card';
import { HighlightDirective } from '../../directives/highlight.directive';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({ selector: 'app-course-list', imports: [NgFor, NgIf, CourseCardComponent, HighlightDirective], templateUrl: './course-list.html', styleUrl: './course-list.css' })
export class CourseListComponent implements OnInit {
  courses: Course[] = [];
  isLoading = true;
  selectedCourseId: number | null = null;
  constructor(private readonly courseService: CourseService) {}
  ngOnInit(): void { this.courses = this.courseService.getCourses(); setTimeout(() => this.isLoading = false, 1500); }
  trackByCourseId(_: number, course: Course): number { return course.id; } // Preserves unchanged DOM nodes when an array changes.
  onEnroll(courseId: number): void { console.log('Enrolling in course: ' + courseId); this.selectedCourseId = courseId; const course = this.courses.find((item) => item.id === courseId); if (course) course.enrolled = true; }
}
