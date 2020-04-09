using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningUpdateService : IScreeningUpdateService
    {
        public Task<Screening> UpdateAsync(ScreeningUpdateModel screening)
        {
            throw new System.NotImplementedException();
        }
    }
}