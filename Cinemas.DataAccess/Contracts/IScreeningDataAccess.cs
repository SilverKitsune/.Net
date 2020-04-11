using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;
using Cinemas.Domain.Models;
namespace Cinemas.DataAccess.Contracts
{
    public interface IScreeningDataAccess
    {
        Task<Screening> InsertAsync(ScreeningUpdateModel screening);
        Task<IEnumerable<Screening>> GetAsync();
        Task<Screening> GetAsync(IScreeningIdentity screeningId);
        Task<Screening> UpdateAsync(ScreeningUpdateModel screening);
        Task<Screening> GetByAsync(IScreeningContainer screening);

    }
}