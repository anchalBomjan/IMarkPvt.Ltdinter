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
    { id:3, name:'Michel Stratch ',email:'michel@gmail.com'},
    {id:4,name:'Ronaldo',email:'ronaldo@gmai.com'},
    {id:5,name:'Hari Narayan Yadav',email:'yadav@gmail.com'}
  ];


  // it hold the current value and emits that  currents value immediately to new subscribers
  //mostly  used in auto UI sync without manual reload i.e data shared across multiple views

  // private studentsSubject = new BehaviorSubject<Student[]>(this.students);
  // students$ = this.studentsSubject.asObservable();


  constructor() { }


// observable  is a  powerful tools for managing asynchronous data streams.Handles operation forn http request
  getAll(): Observable<Student[]> {
    return of(this.students);
  }

  // when a value  might not exits, undefined is used to safed represent "nothing" instead of crashing  the app
  getById(id: number): Observable<Student | undefined> {
    const student = this.students.find(s => s.id === id);
    return of(student);
  }

  //Obserable<void> is suitable if you just want to notify "creation successful"but return of(void 0);
  //if your UI or logical needs the  new student back prefer Obseravable<Student>

  create(student: Student): Observable<boolean> {
    student.id = this.generateId();
    this.students.push(student);
    //this.studentsSubject.next(this.students);
    return of(true);
  }


  update(id:number,updatedStudent:Student):Observable<Boolean>{
    const index= this.students.findIndex(s=>s.id==id);
    if(index!=-1){
     // this.students[index]={...updatedStudent,id};
      //Instead of using three dot we do like this
      this.students[index].id=updatedStudent.id;
      this.students[index].name=updatedStudent.name;
       this.students[index].email=updatedStudent.email;

     // this.studentsSubject.next(this.students);
    }
    return of(true);
  }

// instead of using void  using boolean  return type
  delete(id: number): Observable<boolean> {
    this.students = this.students.filter(s => s.id !== id);
    ////this.studentsSubject.next(this.students);
    //return of(void 0);
    return of(true)
  }

  private generateId(): number {
    return this.students.length > 0
      ? Math.max(...this.students.map(s => s.id)) + 1
      : 1;
  }
}
