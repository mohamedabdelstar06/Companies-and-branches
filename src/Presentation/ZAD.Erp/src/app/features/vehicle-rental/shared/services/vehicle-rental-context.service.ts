import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface VehicleRentalContext {
  companyId: number | null;
  branchId: number | null;
  companyName: string | null;
  branchName: string | null;
  companyLogo?: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class VehicleRentalContextService {
  private contextSubject = new BehaviorSubject<VehicleRentalContext>({
    companyId: null,
    branchId: null,
    companyName: null,
    branchName: null,
    companyLogo: null
  });

  context$ = this.contextSubject.asObservable();

  setContext(context: VehicleRentalContext) {
    this.contextSubject.next(context);
    // Optionally persist to localStorage
    localStorage.setItem('vehicleRentalContext', JSON.stringify(context));
  }

  getContext(): VehicleRentalContext {
    return this.contextSubject.value;
  }

  loadContext() {
    const saved = localStorage.getItem('vehicleRentalContext');
    if (saved) {
      try {
        this.contextSubject.next(JSON.parse(saved));
      } catch (e) {
        console.error('Failed to parse saved context');
      }
    }
  }

  clearContext() {
    const empty: VehicleRentalContext = { companyId: null, branchId: null, companyName: null, branchName: null, companyLogo: null };
    this.contextSubject.next(empty);
    localStorage.removeItem('vehicleRentalContext');
  }

  hasContext(): boolean {
    const ctx = this.getContext();
    return ctx.companyId !== null && ctx.branchId !== null;
  }
}
