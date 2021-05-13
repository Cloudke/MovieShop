import { MovieService } from 'src/app/core/services/movie.service';
import { Component, OnInit } from '@angular/core';
import { MovieDetail } from 'src/app/shared/models/movieDetail';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private movieService:MovieService) { }

  movie:MovieDetail|undefined;

  ngOnInit(): void {
    this.movieService.getMovieDetails(29).subscribe(
      m=> {     
        this.movie=m;
      }
      )

  }

}
