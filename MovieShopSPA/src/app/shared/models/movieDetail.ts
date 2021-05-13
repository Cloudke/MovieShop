import { Cast } from 'src/app/shared/models/cast';
import { Genre } from 'src/app/shared/models/genre';

export interface MovieDetail {
    id: number;
    title: string;
    overview: string;
    tagline: string;
    budget: number;
    revenue?: any;
    imdbUrl?: any;
    tmdbUrl?: any;
    posterUrl: string;
    backdropUrl: string;
    originalLanguage?: any;
    releaseDate: Date;
    runTime: number;
    price?: any;
    createdDate?: any;
    updatedDate?: any;
    updatedBy?: any;
    createdBy?: any;
    rating: number;
    casts: Cast[];
    genres: Genre[];
}



