import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { ResumeService } from '../../services/resume.service';

export interface MyResume {
  id: number;
  name: string;
  content: string;
}

@Component({
  selector: 'app-my-resume-list',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './my-resume-list.component.html',
  styleUrl: './my-resume-list.component.css',
})
export class MyResumeListComponent implements OnInit {
  displayedColumns: string[] = ['nom', 'contenu'];
  private resumeService = inject(ResumeService);
  dataSource: { id: number; name: string; content: string }[] = [];

  ngOnInit(): void {
    this.loadMyResume();
  }

  loadMyResume() {
    const idUtilisateur = 1;
    this.resumeService.getAllResumes(idUtilisateur).subscribe({
      next: (resumes) => {
        this.dataSource = resumes;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
