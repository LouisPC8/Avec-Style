import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom, Observable } from 'rxjs';
import { Outfit } from '../models/outfit';
import { UserSettings } from '../models/userSettings';

@Injectable({
  providedIn: 'root'
})
export class OutfitService {
  private apiUrl = 'https://localhost:7184/api/Articles/GetOutfits';

  constructor(private http: HttpClient) { }

  async getOutfits(settings: UserSettings) {
    let x = await lastValueFrom(this.http.post<any>(this.apiUrl, settings));
    console.log(x)
    return x
  }

  async getTest() {
    let x = await lastValueFrom(this.http.get<any>('https://localhost:7184/api/Articles/GetTest'));
    console.log(x)
    return x
  }
}
