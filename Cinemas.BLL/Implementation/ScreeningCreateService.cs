using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningCreateService : IScreeningCreateService
    {
        public Task<Screening> CreateAsync(ScreeningUpdateModel screening)
        {
            throw new System.NotImplementedException();
        }
    }
}