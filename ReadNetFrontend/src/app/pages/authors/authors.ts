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
    this.showForm = true;
  }

  saveAuthor(): void {

    this.authorService.createAuthor(this.newAuthor)
      .subscribe({
        next: () => {

          this.newAuthor = {
            name: '',
            country: ''
          };

          this.showForm = false;

          this.loadAuthors();
        },
        error: (error) => {
          console.error('Error al crear autor:', error);
        }
      });
  }
}