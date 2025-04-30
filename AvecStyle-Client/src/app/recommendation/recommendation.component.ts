import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsPopupComponent } from '../settings-popup/settings-popup.component';
import { SettingsService } from '../services/settings.service';
import { OutfitService } from '../services/outfit.service';
import { Outfit } from '../models/outfit';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-recommendation',
  standalone: true,
  imports: [SettingsPopupComponent, CommonModule, TranslateModule],
  templateUrl: './recommendation.component.html',
  styleUrl: './recommendation.component.css'
})
export class RecommendationComponent implements OnInit {
  isSettingsOpen = false;
  outfits: Outfit[] = [];
  isLoading = false;
  defaultImageUrl = 'assets/placeholder.png';

  constructor(
    private settingsService: SettingsService,
    private outfitService: OutfitService
  ) { }

  async ngOnInit() {
    if (!this.settingsService.hasSettings()) {
      this.isSettingsOpen = true;
    } else {
      await this.getOutfits();
    }
  }

  async closeSettings() {
    this.isSettingsOpen = false;
    await this.getOutfits();
  }

  async getOutfits() {
    const settings = this.settingsService.getSettings();
    console.log(settings);
    if (settings) {
      try {
        this.isLoading = true;
        this.outfits = await this.outfitService.getOutfits(settings);
      } catch (error) {
        console.error('Error fetching outfits:', error);
      } finally {
        this.isLoading = false;
      }
    }
  }
}
