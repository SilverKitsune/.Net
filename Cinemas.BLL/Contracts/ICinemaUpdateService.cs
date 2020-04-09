using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface ICinemaUpdateService
    {
        Task<Cinema> UpdateAsync(CinemaUpdateModel cinema);
    }
}