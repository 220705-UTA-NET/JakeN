import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'darkMode';

  Rich: string = "";
  Image: string = "";
  Button: string = "";

  darkMode = false;
  constructor() {
    this.defaultTheme();
  }

  defaultTheme() {
    this.darkMode = true;
    document.documentElement.setAttribute('data-theme', this.darkMode ? 'dark' : 'light');
    this.Rich = "Dark Richard";
    this.Image = "./../assets/darkMode.png";
    this.Button = "Embrace the Light side"
  }

  toggleTheme() {
    this.darkMode = !this.darkMode;
    document.documentElement.setAttribute('data-theme', this.darkMode ? 'dark' : 'light')
    if (this.darkMode) {
      this.Rich = "Dark Richard";
      this.Image = "./../assets/darkMode.png";
      this.Button = "Embrace the Light side"
    }
    else {
      this.Rich = "Light Richard"
      this.Image = "./../assets/lightMode.png";
      this.Button = "Join the Dark side"
    }
  }
}
