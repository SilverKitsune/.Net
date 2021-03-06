﻿using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class MovieUpdateService : IMovieUpdateService
    {
        private IMovieDataAccess MovieDataAccess { get; }

        public MovieUpdateService(IMovieDataAccess screeningDataAccess)
        {
            MovieDataAccess = screeningDataAccess;
        }

        public Task<Movie> UpdateAsync(MovieUpdateModel movie)
        {
            return MovieDataAccess.UpdateAsync(movie);
        }
    }
}