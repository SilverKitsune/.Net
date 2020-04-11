using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Contracts
{
    public interface IScreeningGetService
    {
        Task<IEnumerable<Screening>> GetAsync();
        Task<Screening> GetAsync(IScreeningIdentity screening);
        Task ValidateAsync(IScreeningContainer departmentContainer);
    }
}