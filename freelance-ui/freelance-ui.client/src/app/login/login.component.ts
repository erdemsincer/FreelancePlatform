import { Component } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule, RouterModule, CommonModule]
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    console.log('Giriş yapılmaya çalışılıyor:', this.email, this.password);
    this.authService.login(this.email, this.password).subscribe(response => {
      console.log('Gelen response:', response);
      localStorage.setItem('token', response.token);
      alert("Giriş başarılı!");
      this.router.navigate(['/dashboard']);
    }, error => {
      console.error('Hata:', error);
      alert("Hatalı giriş bilgileri!");
    });
  }

  }

