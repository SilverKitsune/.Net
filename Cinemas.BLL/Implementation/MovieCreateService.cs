using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.DataAccess.Implementations;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class MovieCreateService : IMovieCreateService
    {
        private IMovieDataAccess MovieDataAccess { get; }

        public MovieCreateService(IMovieDataAccess screeningDataAccess)
        {
            MovieDataAccess = screeningDataAccess;
        }

        public Task<Movie> CreateAsync(MovieUpdateModel movie)
        {
            return MovieDataAccess.InsertAsync(movie);
        }
    }
}