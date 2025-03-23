import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';   // ✅ Router import et

@Component({
  selector: 'app-login',
  standalone: true,     // ✅ Burada olacak
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  // ✅ ngModel kullanıyorsan FormsModule burada da olmalı
})

export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.email, this.password).subscribe(response => {
      localStorage.setItem('token', response.token);
      alert("Giriş başarılı!");
      this.router.navigate(['/dashboard']);   // ✅ Başarılıysa yönlendir
    }, error => {
      alert("Hatalı giriş bilgileri!");
    });
  }
}
