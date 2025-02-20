declare var google:any;
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { AuthapiService } from '../services/authapi.service';
import { UserDetails } from '../Models/UserDetails';
import { Router } from '@angular/router';

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
    private authApiSerive: AuthapiService,
    private router: Router
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

    localStorage.removeItem("access_token")
    localStorage.removeItem("UserInfo")

    this.authApiSerive.getUserDetails(response.credential).subscribe((res:UserDetails) => {
      localStorage.setItem("access_token", response.credential)
      localStorage.setItem("UserInfo", JSON.stringify(res))

      this.router.navigate(['home']);

    })


  }
  
  decodeToken(token:string){
    return JSON.parse(atob(token.split(".")[1]))
  }

  login(){
  }
}
