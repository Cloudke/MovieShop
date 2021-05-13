import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  constructor(private apiService: ApiService) {}
  //called by movie details component
  getMovieDetails(id: number) {
    // this.apiService.getOne(`${'movies/'}${id}`);
    this.apiService.getOne(`${'movies/'}$`,id);
  }
}