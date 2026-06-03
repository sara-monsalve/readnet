import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  Author,
  AuthorService,
  CreateAuthor
} from '../../services/author.service';

@Component({
  selector: 'app-authors',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './authors.html',
  styleUrl: './authors.css'
})
export class Authors implements OnInit {

  authors: Author[] = [];

  showForm = false;
  isEditing = false;
  editingAuthorId = 0;

  newAuthor: CreateAuthor = {
    name: '',
    country: ''
  };

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.loadAuthors();
  }

  loadAuthors(): void {
    this.authorService.getAuthors().subscribe({
      next: (data) => {
        this.authors = data;
      },
      error: (error) => {
        console.error('Error al obtener autores:', error);
      }
    });
  }

  openForm(): void {

    this.isEditing = false;

    this.newAuthor = {
      name: '',
      country: ''
    };

    this.showForm = true;
  }

  editAuthor(author: Author): void {

    this.isEditing = true;
    this.editingAuthorId = author.id;

    this.newAuthor = {
      name: author.name,
      country: author.country
    };

    this.showForm = true;
  }

  saveAuthor(): void {

    if (this.isEditing) {

      this.authorService
        .updateAuthor(this.editingAuthorId, this.newAuthor)
        .subscribe({
          next: () => {
            this.finishOperation();
          },
          error: (error) => {
            console.error('Error al editar autor:', error);
          }
        });

      return;
    }

    this.authorService
      .createAuthor(this.newAuthor)
      .subscribe({
        next: () => {
          this.finishOperation();
        },
        error: (error) => {
          console.error('Error al crear autor:', error);
        }
      });
  }

  deleteAuthor(id: number): void {

    const confirmDelete = confirm(
      '¿Está seguro de eliminar este autor?'
    );

    if (!confirmDelete) {
      return;
    }

    this.authorService
      .deleteAuthor(id)
      .subscribe({
        next: () => {
          this.loadAuthors();
        },
        error: (error) => {
          console.error('Error al eliminar autor:', error);
        }
      });
  }

  finishOperation(): void {

    this.newAuthor = {
      name: '',
      country: ''
    };

    this.showForm = false;
    this.isEditing = false;
    this.editingAuthorId = 0;

    this.loadAuthors();
  }
}