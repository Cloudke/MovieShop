import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movieCard';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css'],
})
export class MovieCardListComponent implements OnInit {
  movies: MovieCard[] | undefined;
  id?: number;

  constructor(
    private movieService: MovieService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.movieService.getMoviesByGenre(this.id).subscribe((m) => {
        this.movies = m;
      });
    });
  }
}
