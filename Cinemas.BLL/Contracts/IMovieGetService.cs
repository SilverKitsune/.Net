using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Contracts
{
    public interface IMovieGetService
    {
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> GetAsync(IMovieIdentity movie);
    }
}