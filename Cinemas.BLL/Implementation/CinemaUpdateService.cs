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

        public CinemaUpdateService(ICinemaDataAccess cinemaDataAccess)
        {
            CinemaDataAccess = cinemaDataAccess;
        }

        public async Task<Cinema> UpdateAsync(CinemaUpdateModel cinema)
        {
            return await CinemaDataAccess.UpdateAsync(cinema);
        }
    }
}