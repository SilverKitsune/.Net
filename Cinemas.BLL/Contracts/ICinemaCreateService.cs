using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface ICinemaCreateService
    {
        Task<Cinema> CreateAsync(CinemaUpdateModel cinema);
    }
}