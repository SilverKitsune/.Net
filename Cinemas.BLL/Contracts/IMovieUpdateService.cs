using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface IMovieUpdateService
    {
        Task<Movie> UpdateAsync(MovieUpdateModel movie);
    }
}