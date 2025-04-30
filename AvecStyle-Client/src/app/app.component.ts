import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import { SettingsPopupComponent } from './settings-popup/settings-popup.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, SettingsPopupComponent, TranslateModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AvecStyle';
  isSettingsOpen = false;
  language: string = "fr";

  constructor(public translator: TranslateService) {
    this.translator.setDefaultLang(this.language);
    this.translator.use(this.language);
  }

  toggleSettings() {
    this.isSettingsOpen = !this.isSettingsOpen;
  }

  changeLanguage() {
    this.translator.use(this.language);
  }
}
