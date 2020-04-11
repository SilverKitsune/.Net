using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;
using Cinemas.Domain.Models;

namespace Cinemas.DataAccess.Contracts
{
    public interface IMovieDataAccess
    {
        Task<Movie> InsertAsync(MovieUpdateModel movie);
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> GetAsync(IMovieIdentity movieId);
        Task<Movie> UpdateAsync(MovieUpdateModel movie);
        Task<Movie> GetByAsync(IMovieContainer movie);

    }
}