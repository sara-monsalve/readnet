import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  Book,
  BookService,
  CreateBook
} from '../../services/book.service';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class Books implements OnInit {

  books: Book[] = [];

  showForm = false;
  isEditing = false;
  editingBookId = 0;

  newBook: CreateBook = {
    title: '',
    isbn: '',
    publishYear: 2025,
    authorId: 1,
    categoryId: 1
  };

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe({
      next: (data) => {
        this.books = data;
      },
      error: (error) => {
        console.error('Error al obtener libros:', error);
      }
    });
  }

  openForm(): void {

    this.isEditing = false;

    this.newBook = {
      title: '',
      isbn: '',
      publishYear: 2025,
      authorId: 1,
      categoryId: 1
    };

    this.showForm = true;
  }

  editBook(book: Book): void {

    this.isEditing = true;
    this.editingBookId = book.id;

    this.newBook = {
      title: book.title,
      isbn: book.isbn,
      publishYear: book.publishYear,
      authorId: book.authorId,
      categoryId: book.categoryId
    };

    this.showForm = true;
  }

  saveBook(): void {

    if (this.isEditing) {

      this.bookService
        .updateBook(this.editingBookId, this.newBook)
        .subscribe({
          next: () => {
            this.finishOperation();
          },
          error: (error) => {
            console.error('Error al editar libro:', error);
          }
        });

      return;
    }

    this.bookService
      .createBook(this.newBook)
      .subscribe({
        next: () => {
          this.finishOperation();
        },
        error: (error) => {
          console.error('Error al crear libro:', error);
        }
      });
  }

  deleteBook(id: number): void {

    const confirmDelete = confirm(
      '¿Está seguro de eliminar este libro?'
    );

    if (!confirmDelete) {
      return;
    }

    this.bookService
      .deleteBook(id)
      .subscribe({
        next: () => {
          this.loadBooks();
        },
        error: (error) => {
          console.error('Error al eliminar libro:', error);
        }
      });
  }

  finishOperation(): void {

    this.showForm = false;
    this.isEditing = false;
    this.editingBookId = 0;

    this.loadBooks();
  }
}