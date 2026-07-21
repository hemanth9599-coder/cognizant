import { Routes } from '@angular/router';
import { CourseListComponent } from './pages/course-list/course-list';
import { EnrollmentFormComponent } from './pages/enrollment-form/enrollment-form';
import { HomeComponent } from './pages/home/home';
import { ReactiveEnrollmentFormComponent } from './pages/reactive-enrollment-form/reactive-enrollment-form';
import { StudentProfileComponent } from './pages/student-profile/student-profile';

export const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Student Course Portal' },
  { path: 'courses', component: CourseListComponent, title: 'Courses' },
  { path: 'enroll', component: EnrollmentFormComponent, title: 'Enroll' },
  { path: 'enroll-reactive', component: ReactiveEnrollmentFormComponent, title: 'Reactive Enrollment' },
  { path: 'profile', component: StudentProfileComponent, title: 'Profile' },
  { path: '**', redirectTo: '' },
];
