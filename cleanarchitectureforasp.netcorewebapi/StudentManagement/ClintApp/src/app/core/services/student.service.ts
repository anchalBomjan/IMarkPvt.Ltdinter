import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudentDTO } from '../models/student';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private readonly API_URL = '/api/students';

  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<StudentDTO[]> {
    return this.http.get<StudentDTO[]>(this.API_URL);
  }

  getStudentById(id: number): Observable<StudentDTO> {
    return this.http.get<StudentDTO>(`${this.API_URL}/${id}`);
  }

  createStudent(student: StudentDTO): Observable<StudentDTO> {
    return this.http.post<StudentDTO>(this.API_URL, student);
  }

  updateStudent(id: number, student: StudentDTO): Observable<void> {
    return this.http.put<void>(`${this.API_URL}/${id}`, student);
  }

  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
  
}
