import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({ selector: 'app-enrollment-form', imports: [FormsModule, NgIf], templateUrl: './enrollment-form.html', styleUrl: './enrollment-form.css' })
export class EnrollmentFormComponent {
  studentName = '';
  studentEmail = '';
  courseId: number | null = null;
  preferredSemester = '';
  agreeToTerms = false;
  submitted = false;
  onSubmit(form: NgForm): void { console.log('Enrollment form:', form.value, 'Valid:', form.valid); if (form.valid) this.submitted = true; }
  reset(form: NgForm): void { form.resetForm(); this.submitted = false; }
}
