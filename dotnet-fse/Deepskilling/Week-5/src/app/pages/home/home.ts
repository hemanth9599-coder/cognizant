import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../services/course.service';

@Component({ selector: 'app-home', imports: [FormsModule], templateUrl: './home.html', styleUrl: './home.css' })
export class HomeComponent implements OnInit, OnDestroy {
  portalName = 'Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';
  availableCourses = 0;
  constructor(private readonly courseService: CourseService) {}
  ngOnInit(): void { this.availableCourses = this.courseService.getCourses().length; console.log('HomeComponent initialised — courses loaded'); }
  ngOnDestroy(): void { console.log('HomeComponent destroyed'); }
  onEnrollClick(): void { this.message = 'Enrollment opened!'; }
}
