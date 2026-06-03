import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Author {
  id: number;
  name: string;
  country: string;
}

export interface CreateAuthor {
  name: string;
  country: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  private apiUrl = 'https://localhost:7166/api/Author';

  constructor(private http: HttpClient) { }

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.apiUrl);
  }

  createAuthor(author: CreateAuthor): Observable<any> {
    return this.http.post(this.apiUrl, author);
  }

  updateAuthor(id: number, author: CreateAuthor): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, author);
  }

  deleteAuthor(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}