import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SweetAlertService } from './sweet-alert.service';

@Injectable({
  providedIn: 'root'
})
export class FileDownloadService {
  private http = inject(HttpClient);
  private sweetAlert = inject(SweetAlertService);

  constructor() { }

  downloadFile(fileUrl: string, fileName: string) {
    this.http.get(fileUrl, { responseType: 'blob' }).subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.style.display = 'none';
        a.href = url;
        a.download = fileName;
        document.body.appendChild(a);
        a.click();
        window.URL.revokeObjectURL(url);
        document.body.removeChild(a);
      },
      error: (err) => {
        console.error('Error downloading file:', err);
        this.sweetAlert.error('Download Failed', 'Could not download the file. It might have been deleted or the server is unreachable.');
      }
    });
  }
}
