using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class CinemaCreateService : ICinemaCreateService
    {
        public Task<Cinema> CreateAsync(CinemaUpdateModel cinema)
        {
            throw new System.NotImplementedException();
        }
    }
}