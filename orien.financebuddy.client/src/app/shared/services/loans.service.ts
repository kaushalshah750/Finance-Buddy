import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthapiService } from './authapi.service';
import { Loans } from '../Models/Loans';
import { Banks } from '../Models/Banks';

@Injectable({
  providedIn: 'root'
})
export class LoansService {

  private apiUrl = 'api/loans';
  private bankApiUrl = 'api/loans/banks';

  constructor(private authApiService: AuthapiService) {}

  getLoans() {
    return this.authApiService.get<Loans[]>(this.apiUrl)
  }

  addLoan(loan:Loans) {
    return this.authApiService.post<string>(this.apiUrl + "/add", loan)
  }

  updateLoan(loan:Loans) {
    return this.authApiService.post<string>(this.apiUrl + "/update", loan)
  }

  getBanks() {
    return this.authApiService.get<Banks[]>(this.bankApiUrl)
  }
}
