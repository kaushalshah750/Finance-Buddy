declare var google:any;
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  google:any;
  createform = this.formBuilder.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  })
  userInfo:any

  constructor(
    private formBuilder: FormBuilder,
  ){}

  ngOnInit(){
    this.initGoogleAuth()
  }
  
  initGoogleAuth() {
    google.accounts.id.initialize({
      client_id: "156985885803-aqehd6sc7vfnkidaq1h4440dffoao55h.apps.googleusercontent.com",
      callback: this.handleCredentialResponse.bind(this),
      auto_select: false,
      prompt_parent_id: "googleBtn"
    });
    google.accounts.id.renderButton(
      document.getElementById('googleBtn'),
      { theme: 'outline', size: 'large' }
    );
  }

  handleCredentialResponse(response: any) {
    console.log('Google Token:', response);
    console.log('Google Token:', response.credential);
    // Send this token to your backend for verification
  }
  
  decodeToken(token:string){
    return JSON.parse(atob(token.split(".")[1]))
  }

  login(){
  }
}
