import { Component, OnInit } from '@angular/core';
import { NgIf } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({ selector: 'app-course-detail', imports: [NgIf, RouterLink], templateUrl: './course-detail.html', styleUrl: './course-detail.css' })
export class CourseDetailComponent implements OnInit {
  course?: Course;
  error = '';
  constructor(private readonly route: ActivatedRoute, private readonly courseService: CourseService) {}
  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.courseService.getCourseById(id).subscribe({ next: (course) => this.course = course, error: () => this.error = 'Course not found.' });
  }
}
