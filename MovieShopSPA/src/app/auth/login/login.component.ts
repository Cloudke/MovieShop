import { Login } from './../../shared/models/login';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

//two way binding: Augular JS
//one way binding
userLogin:Login = {
  email:'',password:''
}
  constructor() { }

  ngOnInit(): void {
  }

  login(){
    console.log(this.userLogin);
    console.log("button was clicked");
  }

  get twoway(){
    return JSON.stringify(this.userLogin);
  }
}
