import { Injectable } from '@angular/core';
import { Student } from '../models/student';
import { BehaviorSubject, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private students: Student[] = [
    { id: 1, name: 'John Doe', email: 'john@example.com' },
    { id: 2, name: 'Jane Smith', email: 'jane@example.com' },
  ];

  private studentsSubject = new BehaviorSubject<Student[]>(this.students);
  students$ = this.studentsSubject.asObservable();


  constructor() { }



  getAll(): Observable<Student[]> {
    return of(this.students);
  }

  getById(id: number): Observable<Student | undefined> {
    const student = this.students.find(s => s.id === id);
    return of(student);
  }

  create(student: Student): Observable<void> {
    student.id = this.generateId();
    this.students.push(student);
    this.studentsSubject.next(this.students);
    return of();
  }

  update(id: number, updatedStudent: Student): Observable<void> {
    const index = this.students.findIndex(s => s.id === id);
    if (index !== -1) {
      this.students[index] = { ...updatedStudent, id };
      this.studentsSubject.next(this.students);
    }
    return of();
  }

  delete(id: number): Observable<void> {
    this.students = this.students.filter(s => s.id !== id);
    this.studentsSubject.next(this.students);
    return of();
  }

  private generateId(): number {
    return this.students.length > 0
      ? Math.max(...this.students.map(s => s.id)) + 1
      : 1;
  }
}
