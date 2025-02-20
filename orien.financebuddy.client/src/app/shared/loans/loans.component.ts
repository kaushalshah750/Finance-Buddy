import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoansService } from '../services/loans.service';
import { LoanDialogComponent } from './loan-dialog/loan-dialog.component';
import { Loans } from '../Models/Loans';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent {
  loans: Loans[] = [];
  displayedColumns: string[] = ['name', 'bank', 'amount', 'monthly_Emi', 'actions'];

  constructor(
    private loansService: LoansService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getLoans();
  }

  getLoans() {
    this.loansService.getLoans().subscribe((data:Loans[]) => {
      this.loans = data;
    });
  }

  openLoanDialog(loan: any = null) {
    const dialogRef = this.dialog.open(LoanDialogComponent, {
      width: '400px',
      data: loan
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getLoans(); // Refresh the grid after adding/editing a loan
      }
    });
  }
}
