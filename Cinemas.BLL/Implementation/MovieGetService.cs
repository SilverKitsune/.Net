using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    public class MovieGetService : IMovieGetService
    {
        private IMovieDataAccess MovieDataAccess { get; }
        
        public MovieGetService(IMovieDataAccess movieDataAccess)
        {
            this.MovieDataAccess = movieDataAccess;
        }
        public Task<IEnumerable<Movie>> GetAsync()
        {
            return this.MovieDataAccess.GetAsync();
        }

        public Task<Movie> GetAsync(IMovieIdentity movie)
        {
            return this.MovieDataAccess.GetAsync(movie);
        }

        public async Task ValidateAsync(IMovieContainer movieContainer)
        {
            if (movieContainer == null)
            {
                throw new ArgumentNullException(nameof(movieContainer));
            }
            
            var screening = await this.GetBy(movieContainer);

            if (movieContainer.MovieId.HasValue && screening == null)
            {
                throw new InvalidOperationException($"Screening not found by id {movieContainer.MovieId}");
            }
        }
        private Task<Movie> GetBy(IMovieContainer departmentContainer)
        {
            return this.MovieDataAccess.GetByAsync(departmentContainer);
        }
    }
}