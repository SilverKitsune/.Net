using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningUpdateService : IScreeningUpdateService
    {
        private IScreeningDataAccess ScreeningDataAccess { get; }
        private IMovieGetService MovieGetService { get; }
        private ICinemaGetService CinemaGetService { get; }

        public ScreeningUpdateService(IScreeningDataAccess screeningDataAccess, ICinemaGetService cinemaGetService,
            IMovieGetService movieGetService)
        {
            ScreeningDataAccess = screeningDataAccess;
            MovieGetService = movieGetService;
            CinemaGetService = cinemaGetService;
        }

        public async Task<Screening> UpdateAsync(ScreeningUpdateModel screening)
        {
            await MovieGetService.ValidateAsync(screening);
            await CinemaGetService.ValidateAsync(screening);

            return await ScreeningDataAccess.InsertAsync(screening);

        }
    }
}