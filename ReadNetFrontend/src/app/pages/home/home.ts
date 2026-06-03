import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorService } from '../../services/author.service';
import { BookService } from '../../services/book.service';
import { MemberService } from '../../services/member.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {

  totalAuthors = 0;
  totalBooks = 0;
  totalMembers = 0;

  constructor(
    private authorService: AuthorService,
    private bookService: BookService,
    private memberService: MemberService
  ) { }

  ngOnInit(): void {

    this.authorService.getAuthors().subscribe(data => {
      this.totalAuthors = data.length;
    });

    this.bookService.getBooks().subscribe(data => {
      this.totalBooks = data.length;
    });

    this.memberService.getMembers().subscribe(data => {
      this.totalMembers = data.length;
    });

  }
}