import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Book {
  id: number;
  title: string;
  isbn: string;
  publishYear: number;
  authorId: number;
  categoryId: number;
}

export interface CreateBook {
  title: string;
  isbn: string;
  publishYear: number;
  authorId: number;
  categoryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = 'https://localhost:7166/api/Book';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  createBook(book: CreateBook): Observable<any> {
    return this.http.post(this.apiUrl, book);
  }

  updateBook(id: number, book: CreateBook): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, book);
  }

  deleteBook(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}