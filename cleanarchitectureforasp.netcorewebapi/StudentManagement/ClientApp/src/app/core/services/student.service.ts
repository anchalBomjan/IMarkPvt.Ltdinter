import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { HttpClient } from '@angular/common/http';
import { IStudent } from '../models/student';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

 
  private apiUrl = environment.apiUrl + 'Student'; // assuming apiUrl = 'https://localhost:44330/api/'


  constructor(private http:HttpClient) { }


  getAllStudents():Observable<IStudent[]>{
    return this.http.get<IStudent[]>(this.apiUrl);
  }

  getStudentById(id: number): Observable<IStudent> {
    return this.http.get<IStudent>(`${this.apiUrl}/${id}`);
  }

  addStudent(student: IStudent): Observable<IStudent> {
    return this.http.post<IStudent>(this.apiUrl, student);
  }

  updateStudent(id: number, student: IStudent): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, student);
  }

  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
