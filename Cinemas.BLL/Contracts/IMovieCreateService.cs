using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface IMovieCreateService
    {
        Task<Movie> CreateAsync(MovieUpdateModel movie);
    }
}