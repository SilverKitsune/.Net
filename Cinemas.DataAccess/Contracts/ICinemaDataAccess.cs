using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;
using Cinemas.Domain.Models;
namespace Cinemas.DataAccess.Contracts
{
    public interface ICinemaDataAccess
    {
        Task<Cinema> InsertAsync(CinemaUpdateModel cinema);
        Task<IEnumerable<Cinema>> GetAsync();
        Task<Cinema> GetAsync(ICinemaIdentity cinemaId);
        Task<Cinema> UpdateAsync(CinemaUpdateModel cinema);
        Task<Cinema> GetByAsync(ICinemaContainer departmentId);

    }
}