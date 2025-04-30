import { Injectable } from '@angular/core';
import { UserSettings } from '../models/userSettings';
import { Shape } from '../models/shape';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {
  private readonly STORAGE_KEY = 'user_settings';

  saveSettings(settings: UserSettings): void {
    localStorage.setItem(this.STORAGE_KEY, JSON.stringify(settings));
  }

  getSettings(): UserSettings | null {
    const stored = localStorage.getItem(this.STORAGE_KEY);
    if (stored) {
      const settings = JSON.parse(stored);
      // Convert shape from string to number if needed
      const shape = typeof settings.shape === 'string' ? parseInt(settings.shape) : settings.shape;
      return new UserSettings(settings.gender, settings.style, shape as Shape);
    }
    return null;
  }

  hasSettings(): boolean {
    return localStorage.getItem(this.STORAGE_KEY) !== null;
  }

  clearSettings(): void {
    localStorage.removeItem(this.STORAGE_KEY);
  }
}
