import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Member {
  id: number;
  fullName: string;
  email: string;
  phone: string;
}

export interface CreateMember {
  fullName: string;
  email: string;
  phone: string;
}

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  private apiUrl = 'https://localhost:7166/api/Member';

  constructor(private http: HttpClient) { }

  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.apiUrl);
  }

  createMember(member: CreateMember): Observable<any> {
    return this.http.post(this.apiUrl, member);
  }

  updateMember(id: number, member: CreateMember): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, member);
  }

  deleteMember(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}