import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserSettings } from '../models/userSettings';
import { SettingsService } from '../services/settings.service';
import { Shape } from '../models/shape';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-settings-popup',
  standalone: true,
  imports: [CommonModule, FormsModule, TranslateModule],
  templateUrl: './settings-popup.component.html',
  styleUrls: ['./settings-popup.component.css']
})
export class SettingsPopupComponent implements OnInit {
  @Input() isOpen = false;
  @Output() closePopup = new EventEmitter<void>();

  gender: boolean = true;
  style: string = 'streetwear';
  shape: Shape = Shape.Hourglass;

  shapes = [
    { value: Shape.Hourglass, label: 'Hourglass' },
    { value: Shape.Pear, label: 'Pear' },
    { value: Shape.InvertedTriangle, label: 'Inverted-Triangle' },
    { value: Shape.Rectangle, label: 'Rectangle' },
    { value: Shape.Apple, label: 'Apple' }
  ];

  constructor(private settingsService: SettingsService) { }

  ngOnInit() {
    // Load saved settings if they exist
    const savedSettings = this.settingsService.getSettings();
    if (savedSettings) {
      this.gender = savedSettings.gender;
      this.style = savedSettings.style;
      this.shape = savedSettings.shape;
    }
  }

  close() {
    if (this.settingsService.hasSettings()) {
      this.closePopup.emit();
    }
  }

  saveSettings() {
    const settings = new UserSettings(this.gender, this.style, this.shape);
    this.settingsService.saveSettings(settings);
    this.closePopup.emit();
  }
}
