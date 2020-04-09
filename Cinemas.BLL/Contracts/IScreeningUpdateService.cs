using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Contracts
{
    public interface IScreeningUpdateService
    {
        Task<Screening> UpdateAsync(ScreeningUpdateModel screening);
    }
}