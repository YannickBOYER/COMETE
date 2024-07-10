import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PDFDocument } from 'pdf-lib';
import { ResumeService } from '../../services/resume.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { Folder } from '../folder-list/folder-list.component';
import { FolderSelectDialogComponent } from '../folder-select-dialog/folder-select-dialog.component';

@Component({
  selector: 'app-upload-ia',
  standalone: true,
  imports: [FormsModule, CommonModule, MatButtonModule],
  templateUrl: './upload-ia.component.html',
  styleUrl: './upload-ia.component.css',
})
export class UploadIaComponent {
  textInput: string = '';
  customInstructions: string = '';
  responseText: string = '';
  documentTitle: string = '';

  private readonly resumeService = inject(ResumeService);
  private readonly dialog = inject(MatDialog);

  onDragOver(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
  }

  async onFileDrop(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();

    const files = event.dataTransfer?.files;
    if (files && files.length > 0) {
      const file = files[0];
      if (file.type === 'application/pdf') {
        const text = await this.extractTextFromPDF(file);
        this.sendTextToService(text, this.customInstructions);
      }
    }
  }

  async onFileClick(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      if (file.type === 'application/pdf') {
        const text = await this.extractTextFromPDF(file);
        this.sendTextToService(text, this.customInstructions);
      }
    }
  }

  async extractTextFromPDF(file: File): Promise<string> {
    const arrayBuffer = await file.arrayBuffer();
    const pdfDoc = await PDFDocument.load(arrayBuffer);
    let text = '';
    for (const page of pdfDoc.getPages()) {
      // text += await page.getTextContent();
    }
    return text;
  }

  onEnter() {
    this.sendTextToService(this.textInput, this.customInstructions);
  }

  sendTextToService(prompt: string, instructions: string) {
    this.resumeService.sendText(prompt, instructions).subscribe({
      next: (response) => {
        console.log('Text sent to service successfully:', response);
        this.responseText = response;
      },
      error: (error) => {
        console.error('Error sending text to service:', error);
      },
    });
  }

  openFolderSelectDialog(): void {
    const idUtilisateur = 1; // Utilisateur ID par défaut ou récupéré dynamiquement
    this.resumeService.getFolders(idUtilisateur).subscribe({
      next: (folders: Folder[]) => {
        const dialogRef = this.dialog.open(FolderSelectDialogComponent, {
          data: { folders, documentTitle: this.documentTitle },
        });

        dialogRef.afterClosed().subscribe((result) => {
          if (result) {
            console.log('Dossier sélectionné:', result.folder);
            console.log('Titre du document:', result.documentTitle);
            const myResume = {
              id: result.folder.id,
              name: result.documentTitle,
              content: this.responseText,
            };
            this.resumeService.saveResume(myResume).subscribe({
              next: (response) => {
                console.log('Resume saved:', response);
              },
              error: (error) => {
                console.error('Error saving resume:', error);
              },
            });
          }
        });
      },
      error: (error) => {
        console.error('Error fetching folders:', error);
      },
    });
  }
}
