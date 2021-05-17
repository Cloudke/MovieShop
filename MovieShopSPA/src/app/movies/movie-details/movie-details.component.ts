import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Component, OnInit } from '@angular/core';
import { MovieDetail } from 'src/app/shared/models/movieDetail';

import { switchMap } from 'rxjs/operators';
import { toInteger } from '@ng-bootstrap/ng-bootstrap/util/util';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css'],
})
export class MovieDetailsComponent implements OnInit {
  constructor(
    private movieService: MovieService,
    private route: ActivatedRoute
  ) {}

  movie: MovieDetail | undefined;
  id?: number;

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];

      this.movieService.getMovieDetails(this.id).subscribe((m) => {
        this.movie = m;
      });
    });
  }
}
