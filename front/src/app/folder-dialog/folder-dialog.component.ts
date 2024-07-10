import { Component } from '@angular/core';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-folder-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatInputModule, FormsModule],
  templateUrl: './folder-dialog.component.html',
  styleUrl: './folder-dialog.component.css',
})
export class FolderDialogComponent {
  folderName: string = '';

  constructor(public dialogRef: MatDialogRef<FolderDialogComponent>) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  onValidateClick(): void {
    if (this.folderName.trim()) {
      this.dialogRef.close(this.folderName);
    }
  }
}
