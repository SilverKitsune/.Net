using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class MovieUpdateService : IMovieUpdateService
    {
        private IMovieDataAccess MovieDataAccess { get; }
        private IScreeningGetService ScreeningGetService { get; }

        public MovieUpdateService(IMovieDataAccess screeningDataAccess, IScreeningGetService screeningGetService)
        {
            MovieDataAccess = screeningDataAccess;
            ScreeningGetService = screeningGetService;
        }

        public async Task<Movie> UpdateAsync(MovieUpdateModel movie)
        {
            await ScreeningGetService.ValidateAsync(movie);

            return await MovieDataAccess.UpdateAsync(movie);

        }
    }
}