import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GenresComponent } from './genres/genres.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
import { FavoriteButtonComponent } from './shared/components/favorite-button/favorite-button.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { PurchasesComponent } from './user/purchases/purchases.component';
import { FavoritesComponent } from './user/favorites/favorites.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
// import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
// import{faCalendarAlt} from '@fortawesome/free-solid-svg-icons';


@NgModule({
  declarations: [
    AppComponent,
    GenresComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    CreateMovieComponent,
    CreateCastComponent,
    MovieCardListComponent,
    MovieCardComponent,
    FavoriteButtonComponent,
    NotFoundComponent,
    PurchasesComponent,
    FavoritesComponent,
    MovieDetailsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbDropdownModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    // FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
