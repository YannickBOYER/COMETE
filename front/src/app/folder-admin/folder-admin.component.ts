import { Component, ViewChild } from '@angular/core';
import { FolderListComponent } from '../components/folder-list/folder-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { FolderDialogComponent } from '../folder-dialog/folder-dialog.component';
import { ResumeService } from '../services/resume.service';
import { FolderSelectDialogComponent } from '../components/folder-select-dialog/folder-select-dialog.component';

@Component({
  selector: 'app-folder-admin',
  standalone: true,
  imports: [FolderListComponent, MatButtonModule],
  templateUrl: './folder-admin.component.html',
  styleUrl: './folder-admin.component.css',
})
export class FolderAdminComponent {
  @ViewChild(FolderListComponent) folderListComponent!: FolderListComponent;

  constructor(public dialog: MatDialog, private resumeService: ResumeService) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(FolderDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        console.log(`Nom du dossier: ${result}`);
        this.resumeService.createFolder(result).subscribe((response) => {
          console.log(response);
          this.folderListComponent.loadFolders();
        });
      }
    });
  }
}
