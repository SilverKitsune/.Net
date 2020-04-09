using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    public class CinemaGetService : ICinemaGetService
    {
        public Task<IEnumerable<Cinema>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Cinema> GetAsync(ICinemaIdentity cinema)
        {
            throw new System.NotImplementedException();
        }
    }
}