using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.DataAccess.Implementations;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class CinemaCreateService : ICinemaCreateService
    {
        private ICinemaDataAccess CinemaDataAccess { get; }
        //private IScreeningGetService ScreeningGetService { get; }

        public CinemaCreateService(ICinemaDataAccess cinemaDataAccess, IScreeningGetService screeningGetService)
        {
            CinemaDataAccess = cinemaDataAccess;
            //  ScreeningGetService = screeningGetService;
        }

        public async Task<Cinema> CreateAsync(CinemaUpdateModel cinema)
        {
            // await ScreeningGetService.ValidateAsync(movie);

            return await CinemaDataAccess.InsertAsync(cinema);

        }
    }
}