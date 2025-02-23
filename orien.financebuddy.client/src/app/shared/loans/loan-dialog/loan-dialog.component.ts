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
      bank: [this.data?.bank.id || '', Validators.required],
      amount: [this.data?.amount || '', Validators.required],
      monthlyEmi: [this.data?.monthly_Emi || '', Validators.required]
    });
  }

  getBankList(){
    this.loanSerive.getBanks().subscribe((res:Banks[]) => {
      this.banks = res
    })
  }

  onSubmit() {
    console.log("onSubmit()")
    if (this.loanForm.valid) {
      var loan:Loans = {
        id: this.data != null ? this.data.id : 0,
        amount: this.loanForm.controls['amount'].value,
        bank: this.loanForm.controls['bank'].value,
        addedBy_UId: '',
        createdDate: new Date(Date.now()),
        monthly_Emi: this.loanForm.controls['monthlyEmi'].value,
        name: this.loanForm.controls['name'].value,
        updatedDate: new Date(Date.now())
      }

      if(this.data){
        this.loanSerive.updateLoan(loan).subscribe((res:boolean) => {
          if(res){
            this.dialogRef.close(this.loanForm.value);
          }
        })
      }else{
        this.loanSerive.addLoan(loan).subscribe((res:boolean) => {
          if(res){
            this.dialogRef.close(this.loanForm.value);
          }
        })
      }

    }
  }

  onClose() {
    console.log("onClose()")
    this.dialogRef.close();
  }
}
