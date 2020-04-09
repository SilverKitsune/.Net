using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class MovieCreateService : IMovieCreateService
    {
        public Task<Movie> CreateAsync(MovieUpdateModel movie)
        {
            throw new System.NotImplementedException();
        }
    }
}