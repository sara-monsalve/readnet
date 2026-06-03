import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Member, MemberService } from '../../services/member.service';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './members.html',
  styleUrl: './members.css'
})
export class Members implements OnInit {

  members: Member[] = [];

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.memberService.getMembers().subscribe({
      next: (data) => {
        this.members = data;
      },
      error: (error) => {
        console.error('Error al obtener miembros:', error);
      }
    });
  }
}