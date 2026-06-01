import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Author, AuthorService } from '../../services/author.service';

@Component({
  selector: 'app-authors',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './authors.html',
  styleUrl: './authors.css'
})
export class Authors implements OnInit {

  authors: Author[] = [];

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.authorService.getAuthors().subscribe({
      next: (data) => {
        this.authors = data;
      },
      error: (error) => {
        console.error('Error al obtener autores:', error);
      }
    });
  }
}