using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Contracts
{
    public interface ICinemaGetService
    {
        Task<IEnumerable<Cinema>> GetAsync();
        Task<Cinema> GetAsync(ICinemaIdentity cinema);
        Task ValidateAsync(ICinemaContainer departmentContainer);
    }
}