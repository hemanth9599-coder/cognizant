import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';

@Injectable({ providedIn: 'root' })
export class CourseService {
  private readonly courses: Course[] = [
    { id: 1, name: 'Angular Fundamentals', code: 'NG101', credits: 3, gradeStatus: 'passed' },
    { id: 2, name: 'Data Structures', code: 'CS201', credits: 4, gradeStatus: 'pending' },
    { id: 3, name: 'Database Systems', code: 'DB220', credits: 3, gradeStatus: 'failed' },
    { id: 4, name: 'Web Engineering', code: 'WE310', credits: 4, gradeStatus: 'pending' },
    { id: 5, name: 'Communication Skills', code: 'CM105', credits: 1, gradeStatus: 'passed' },
  ];

  getCourses(): Course[] { return this.courses; }
  getCourseById(id: number): Course | undefined { return this.courses.find((course) => course.id === id); }
  addCourse(course: Course): void { this.courses.push(course); }
}
