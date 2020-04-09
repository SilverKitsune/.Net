using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface IScreeningCreateService
    {
        Task<Screening> CreateAsync(ScreeningUpdateModel screening);
    }
}