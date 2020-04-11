using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningCreateService : IScreeningCreateService
    {
        private IScreeningDataAccess ScreeningDataAccess { get; }
        private IMovieGetService MovieGetService { get; }
        private ICinemaGetService CinemaGetService { get; }

        public ScreeningCreateService(IScreeningDataAccess screeningDataAccess, ICinemaGetService cinemaGetService,
            IMovieGetService movieGetService)
        {
            ScreeningDataAccess = screeningDataAccess;
            MovieGetService = movieGetService;
            CinemaGetService = cinemaGetService;
        }

        public async Task<Screening> CreateAsync(ScreeningUpdateModel screening)
        {
            await MovieGetService.ValidateAsync(screening);
            await CinemaGetService.ValidateAsync(screening);

            return await ScreeningDataAccess.InsertAsync(screening);

        }
    }
}