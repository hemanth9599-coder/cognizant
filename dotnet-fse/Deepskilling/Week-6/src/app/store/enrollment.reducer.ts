import { createReducer, on } from '@ngrx/store';
import { enrollInCourse, unenrollFromCourse } from './enrollment.actions';
export interface EnrollmentState { enrolledCourseIds: number[]; }
export const enrollmentReducer = createReducer({ enrolledCourseIds: [] } as EnrollmentState,
  on(enrollInCourse, (state, { courseId }) => state.enrolledCourseIds.includes(courseId) ? state : ({ enrolledCourseIds: [...state.enrolledCourseIds, courseId] })),
  on(unenrollFromCourse, (state, { courseId }) => ({ enrolledCourseIds: state.enrolledCourseIds.filter((id) => id !== courseId) })),
);
