import { Component } from '@angular/core';
import { UserInfo } from '../Models/UserInfo';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  user:UserInfo | null = {
    uid: "",
    name: "",
    email: "",
    picture: ""
  }

  constructor(){
    this.user = JSON.parse(localStorage.getItem("UserInfo")!);
  }

  ngOnInit(){
  }
}
