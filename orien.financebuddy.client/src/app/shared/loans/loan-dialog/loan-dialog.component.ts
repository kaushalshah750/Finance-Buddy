import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoansService } from '../../services/loans.service';
import { Banks } from '../../Models/Banks';
import { Loans } from '../../Models/Loans';

@Component({
  selector: 'app-loan-dialog',
  templateUrl: './loan-dialog.component.html',
  styleUrls: ['./loan-dialog.component.css']
})
export class LoanDialogComponent {
  loanForm!: FormGroup;
  banks:Banks[] = []

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<LoanDialogComponent>,
    private loanSerive: LoansService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit() {
    this.getBankList()
    this.loanForm = this.fb.group({
      name: [this.data?.name || '', Validators.required],
      bank: [this.data?.bank || '', Validators.required],
      amount: [this.data?.amount || '', Validators.required],
      monthlyEmi: [this.data?.monthly_Emi || '']
    });
  }

  getBankList(){
    this.loanSerive.getBanks().subscribe((res:Banks[]) => {
      this.banks = res
    })
  }

  onSubmit() {
    if (this.loanForm.valid) {
      var loan:Loans = {
        Id: this.data.id ?? 0,
        Amount: this.loanForm.controls['amount'].value,
        Bank: this.loanForm.controls['bank'].value,
        AddedBy_UId: '',
        CreatedDate: new Date(Date.now()),
        Monthly_Emi: this.loanForm.controls['monthlyEmi'].value,
        Name: this.loanForm.controls['name'].value,
        UpdatedDate: new Date(Date.now())
      }

      if(this.data){
        this.loanSerive.updateLoan(loan).subscribe((res:string) => {})
      }else{
        this.loanSerive.addLoan(loan).subscribe((res:string) => {})
      }

      this.dialogRef.close(this.loanForm.value);
    }
  }

  onClose() {
    this.dialogRef.close();
  }
}
