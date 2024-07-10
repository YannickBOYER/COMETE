import { Component } from '@angular/core';
import { MyResumeListComponent } from '../my-resume-list/my-resume-list.component';
import { FolderListComponent } from '../folder-list/folder-list.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MyResumeListComponent, FolderListComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {}
