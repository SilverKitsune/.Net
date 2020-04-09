using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningGetService : IScreeningGetService
    {
        public Task<IEnumerable<Screening>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Screening> GetAsync(IScreeningIdentity screening)
        {
            throw new System.NotImplementedException();
        }
    }
}