import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecommendationComponent } from './recommendation/recommendation.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'recommendation', component: RecommendationComponent },
];
