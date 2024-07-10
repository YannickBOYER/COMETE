import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { ResumeService } from '../../services/resume.service';

export interface Folder {
  name: string;
  tag: string;
}

@Component({
  selector: 'app-folder-list',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './folder-list.component.html',
  styleUrl: './folder-list.component.css',
})
export class FolderListComponent implements OnInit {
  displayedColumns: string[] = ['nom', 'tag'];
  dataSource: Folder[] = [
    {
      name: 'Dossier A',
      tag: 'Tag vert',
    },
    {
      name: 'Dossier B',
      tag: 'Tag bleu',
    },
    {
      name: 'Dossier C',
      tag: 'Tag vert',
    },
    {
      name: 'Dossier D',
      tag: 'Tag jaune',
    },
  ];

  private resumeService = inject(ResumeService);

  ngOnInit(): void {
    this.loadFolders();
  }

  createFolder(name: string) {
    this.resumeService.createFolder(name).subscribe({
      next: (data) => {
        console.log('Folder created:', data);
      },
      error: (error) => {
        console.error('Error creating folder:', error);
      },
    });
  }

  loadFolders() {
    const idUtilisateur = 1;
    this.resumeService.getFolders(idUtilisateur).subscribe({
      next: (data: Folder[]) => {
        this.dataSource = data;
      },
      error: (error) => {
        console.error('Error fetching folders:', error);
      },
    });
  }
}
