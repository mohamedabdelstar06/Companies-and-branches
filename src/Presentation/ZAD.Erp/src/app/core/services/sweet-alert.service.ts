import { Injectable } from '@angular/core';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SweetAlertService {

  constructor() { }

  confirm(title: string, text: string, confirmButtonText: string = 'Confirm'): Promise<boolean> {
    return Swal.fire({
      title: title,
      text: text,
      icon: 'question',
      iconColor: '#d33', 
      showCancelButton: true,
      confirmButtonColor: '#d33', 
      cancelButtonColor: '#fff',
      cancelButtonText: '<span style="color: black">Cancel</span>',
      confirmButtonText: confirmButtonText,
      customClass: {
        cancelButton: 'border border-secondary text-dark'
      }
    }).then((result) => {
      return result.isConfirmed;
    });
  }

  /**
   * Shows a success toast message
   */
  success(title: string, text: string = '') {
    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: title,
      text: text,
      showConfirmButton: false,
      timer: 3000,
      timerProgressBar: true,
      background: '#d1e7dd', // Light green background
      color: '#0f5132', // Dark green text
      iconColor: '#0f5132', // Dark green icon
      customClass: {
        popup: 'colored-toast'
      }
    });
  }

  /**
   * Shows an error message
   */
  error(title: string, text: string = '') {
    Swal.fire({
      icon: 'error',
      title: title,
      text: text,
      confirmButtonColor: '#d33'
    });
  }
}
