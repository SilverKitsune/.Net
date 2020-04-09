using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class CinemaUpdateService : ICinemaUpdateService
    {
        public Task<Cinema> UpdateAsync(CinemaUpdateModel cinema)
        {
            throw new System.NotImplementedException();
        }
    }
}