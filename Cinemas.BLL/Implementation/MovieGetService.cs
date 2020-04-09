using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    public class MovieGetService : IMovieGetService
    {
        public Task<IEnumerable<Movie>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetAsync(IMovieIdentity movie)
        {
            throw new System.NotImplementedException();
        }
    }
}