import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  return:number[] = []
  totalInvestment:number = 0
  
  createForm = this.formBuilder.nonNullable.group({
    montly: [5000, Validators.required],
    interestRate: [15, Validators.required],
    years: [10, Validators.required],
  })

  constructor(
    private formBuilder: FormBuilder
  ){}

  ngOnInit(){
    this.calculateReturn()
  }

  calculateReturn(){
    this.return = this.calculateCompoundInterest(0, this.createForm.controls['montly'].value, this.createForm.controls['interestRate'].value, this.createForm.controls['years'].value)
    this.totalInvestment = this.totalInvested(this.createForm.controls['montly'].value, this.createForm.controls['years'].value)
  }

  totalInvested(monthlyContribution:number, years:number){
    var months = years * 12;
    return monthlyContribution * months
  }

  calculateCompoundInterest(principal: number, monthlyContribution: number, annualInterestRate: number, years: number): number[] {
    let totalAmounts: number[] = [];
    let amount = principal;
    for (let year = 1; year <= years; year++) {
      for (let month = 1; month <= 12; month++) {
        amount += monthlyContribution;
        amount *= (1 + (annualInterestRate / 100) / 12);
      }
      totalAmounts.push(Math.floor(amount));
    }
    return totalAmounts;
  }
}
