import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  Member,
  MemberService,
  CreateMember
} from '../../services/member.service';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './members.html',
  styleUrl: './members.css'
})
export class Members implements OnInit {

  members: Member[] = [];

  showForm = false;
  isEditing = false;
  editingMemberId = 0;

  newMember: CreateMember = {
    fullName: '',
    email: '',
    phone: ''
  };

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers(): void {
    this.memberService.getMembers().subscribe({
      next: (data) => {
        this.members = data;
      },
      error: (error) => {
        console.error('Error al obtener miembros:', error);
      }
    });
  }

  openForm(): void {

    this.isEditing = false;

    this.newMember = {
      fullName: '',
      email: '',
      phone: ''
    };

    this.showForm = true;
  }

  editMember(member: Member): void {

    this.isEditing = true;
    this.editingMemberId = member.id;

    this.newMember = {
      fullName: member.fullName,
      email: member.email,
      phone: member.phone
    };

    this.showForm = true;
  }

  saveMember(): void {

    if (this.isEditing) {

      this.memberService
        .updateMember(this.editingMemberId, this.newMember)
        .subscribe({
          next: () => {
            this.finishOperation();
          },
          error: (error) => {
            console.error('Error al editar miembro:', error);
          }
        });

      return;
    }

    this.memberService
      .createMember(this.newMember)
      .subscribe({
        next: () => {
          this.finishOperation();
        },
        error: (error) => {
          console.error('Error al crear miembro:', error);
        }
      });
  }

  deleteMember(id: number): void {

    const confirmDelete = confirm(
      '¿Está seguro de eliminar este miembro?'
    );

    if (!confirmDelete) {
      return;
    }

    this.memberService
      .deleteMember(id)
      .subscribe({
        next: () => {
          this.loadMembers();
        },
        error: (error) => {
          console.error('Error al eliminar miembro:', error);
        }
      });
  }

  finishOperation(): void {

    this.showForm = false;
    this.isEditing = false;
    this.editingMemberId = 0;

    this.loadMembers();
  }
}