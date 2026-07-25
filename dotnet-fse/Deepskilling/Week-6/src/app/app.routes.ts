import { Routes } from '@angular/router';
import { CourseListComponent } from './pages/course-list/course-list';
import { HomeComponent } from './pages/home/home';
import { StudentProfileComponent } from './pages/student-profile/student-profile';
import { CoursesLayoutComponent } from './pages/courses-layout/courses-layout';
import { CourseDetailComponent } from './pages/course-detail/course-detail';
import { NotFoundComponent } from './pages/not-found/not-found';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Student Course Portal' },
  { path: 'courses', component: CoursesLayoutComponent, title: 'Courses', children: [{ path: '', component: CourseListComponent }, { path: ':id', component: CourseDetailComponent }] },
  { path: 'enroll', canActivate: [authGuard], loadChildren: () => import('./features/enrollment/enrollment.routes').then((m) => m.ENROLLMENT_ROUTES) },
  { path: 'profile', canActivate: [authGuard], component: StudentProfileComponent, title: 'Profile' },
  { path: '**', component: NotFoundComponent, title: 'Page not found' },
];
