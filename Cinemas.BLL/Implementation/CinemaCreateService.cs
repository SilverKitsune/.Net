using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class CinemaCreateService : ICinemaCreateService
    {
        private ICinemaDataAccess CinemaDataAccess { get; }

        public CinemaCreateService(ICinemaDataAccess cinemaDataAccess)
        {
            CinemaDataAccess = cinemaDataAccess;
        }

        public  Task<Cinema> CreateAsync(CinemaUpdateModel cinema)
        {
            return CinemaDataAccess.InsertAsync(cinema);
        }
    }
}