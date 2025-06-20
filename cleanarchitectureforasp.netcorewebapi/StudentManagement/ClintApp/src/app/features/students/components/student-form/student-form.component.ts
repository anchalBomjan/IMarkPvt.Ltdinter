import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from 'src/app/core/services/student.service';
import { MessageService } from 'primeng/api';
import { StudentDTO } from 'src/app/core/models/student';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html'
})
export class StudentFormComponent implements OnInit {
  form: FormGroup;
  isEdit = false;
  loading = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private studentService: StudentService,
    private messageService: MessageService
  ) {
    this.form = this.fb.group({
      id: [null],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      enrollmentDate: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.loadStudent(id);
    }
  }

  loadStudent(id: number): void {
    this.loading = true;
    this.studentService.getStudentById(id).subscribe({
      next: (student) => {
        this.form.patchValue({
          ...student,
          enrollmentDate: new Date(student.enrollmentDate)
        });
        this.loading = false;
      },
      error: () => {
        this.showError('Failed to load student');
        this.router.navigate(['/students']);
      }
    });
  }

  onSubmit(): void {
    if (this.form.invalid) return;

    this.loading = true;
    const student: StudentDTO = this.form.value;

    const operation = this.isEdit
      ? this.studentService.updateStudent(student.id, student)
      : this.studentService.createStudent(student);

    operation.subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: `Student ${this.isEdit ? 'updated' : 'created'} successfully`
        });
        this.router.navigate(['/students']);
      },
      error: () => {
        this.showError(`Failed to ${this.isEdit ? 'update' : 'create'} student`);
        this.loading = false;
      }
    });
  }
  cancel(): void {
    this.router.navigate(['/students']);
  }
  
  private showError(detail: string): void {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail
    });
  }
}