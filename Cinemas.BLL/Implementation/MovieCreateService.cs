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
        //private IScreeningGetService ScreeningGetService { get; }

        public MovieCreateService(IMovieDataAccess screeningDataAccess, IScreeningGetService screeningGetService)
        {
            MovieDataAccess = screeningDataAccess;
          //  ScreeningGetService = screeningGetService;
        }

        public async Task<Movie> CreateAsync(MovieUpdateModel movie)
        {
           // await ScreeningGetService.ValidateAsync(movie);

            return await MovieDataAccess.InsertAsync(movie);

        }
    }
}