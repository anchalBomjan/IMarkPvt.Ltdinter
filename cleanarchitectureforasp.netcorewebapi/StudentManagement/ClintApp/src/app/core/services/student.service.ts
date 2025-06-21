import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentDTO } from '../models/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'https://localhost:44330/api/Student';

  constructor(private http: HttpClient) {}

  getAllStudents(): Observable<StudentDTO[]> {
    return this.http.get<StudentDTO[]>(this.apiUrl);
  }

  getStudentById(id: number): Observable<StudentDTO> {
    return this.http.get<StudentDTO>(`${this.apiUrl}/${id}`);
  }

  createStudent(student: StudentDTO): Observable<StudentDTO> {
    return this.http.post<StudentDTO>(this.apiUrl, student);
  }

  updateStudent(id: number, student: StudentDTO): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, student);
  }

  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
