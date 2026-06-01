import { Routes } from '@angular/router';

import { Books } from './pages/books/books';
import { Authors } from './pages/authors/authors';
import { Members } from './pages/members/members';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'books',
    pathMatch: 'full'
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