using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class MovieUpdateService : IMovieUpdateService
    {
        public Task<Movie> UpdateAsync(MovieUpdateModel movie)
        {
            throw new System.NotImplementedException();
        }
    }
}