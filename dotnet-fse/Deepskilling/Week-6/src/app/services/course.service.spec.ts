import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { CourseService } from './course.service';
describe('CourseService', () => { let service: CourseService; let http: HttpTestingController; beforeEach(() => { TestBed.configureTestingModule({ providers: [CourseService, provideHttpClient(), provideHttpClientTesting()] }); service = TestBed.inject(CourseService); http = TestBed.inject(HttpTestingController); }); afterEach(() => http.verify()); it('loads courses from the API', () => { let received = 0; service.getCourses().subscribe((courses) => received = courses.length); http.expectOne('http://localhost:3000/courses').flush([{ id: 1, name: 'Angular', code: 'NG101', credits: 3, gradeStatus: 'passed' }]); expect(received).toBe(1); }); });
