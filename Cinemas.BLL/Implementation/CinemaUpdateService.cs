using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class CinemaUpdateService : ICinemaUpdateService
    {
        private ICinemaDataAccess CinemaDataAccess { get; }
        private IScreeningGetService ScreeningGetService { get; }

        public CinemaUpdateService(ICinemaDataAccess cinemaDataAccess)//, IScreeningGetService screeningGetService)
        {
            CinemaDataAccess = cinemaDataAccess;
            //ScreeningGetService = screeningGetService;
        }

        public async Task<Cinema> UpdateAsync(CinemaUpdateModel cinema)
        {
            //await ScreeningGetService.ValidateAsync(cinema);

            return await CinemaDataAccess.UpdateAsync(cinema);

        }
    }
}