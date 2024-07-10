import { Component, Inject } from '@angular/core';
import { Folder } from '../folder-list/folder-list.component';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-folder-select-dialog',
  standalone: true,
  imports: [
    MatTableModule,
    MatButtonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './folder-select-dialog.component.html',
  styleUrl: './folder-select-dialog.component.css',
})
export class FolderSelectDialogComponent {
  displayedColumns: string[] = ['name', 'tag', 'select'];
  dataSource: MatTableDataSource<Folder>;
  documentTitle = '';

  constructor(
    public dialogRef: MatDialogRef<FolderSelectDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { folders: Folder[]; documentTitle: string }
  ) {
    this.dataSource = new MatTableDataSource(data.folders);
    this.documentTitle = data.documentTitle;
  }

  onSelect(folder: Folder): void {
    this.dialogRef.close({ folder, documentTitle: this.documentTitle });
  }
}
