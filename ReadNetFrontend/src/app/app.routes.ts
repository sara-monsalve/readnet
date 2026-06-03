import { Routes } from '@angular/router';

import { Books } from './pages/books/books';
import { Authors } from './pages/authors/authors';
import { Members } from './pages/members/members';
import { Home } from './pages/home/home';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'books',
    component: Books
  },
  {
    path: 'authors',
    component: Authors
  },
  {
    path: 'members',
    component: Members
  }
];