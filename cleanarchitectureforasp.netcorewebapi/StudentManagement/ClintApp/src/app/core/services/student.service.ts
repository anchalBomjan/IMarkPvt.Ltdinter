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

  updateStudent(id: number, student: StudentDTO): Observable<void> {
    return this.http.put<void>(`${this.API_URL}/${id}`, student);
  }
  
  createStudent(student: StudentDTO): Observable<void> {
    return this.http.post<void>(this.API_URL, student);
  }
  

  deleteStudent(id: number): Observable<any> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
  
}
