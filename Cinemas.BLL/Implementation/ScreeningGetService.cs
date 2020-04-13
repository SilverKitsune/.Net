using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    public class ScreeningGetService : IScreeningGetService
    {
        private IScreeningDataAccess ScreeningDataAccess { get; }
        
        public ScreeningGetService(IScreeningDataAccess cinemaDataAccess)
        {
            this.ScreeningDataAccess = cinemaDataAccess;
        }
        public Task<IEnumerable<Screening>> GetAsync()
        {
            return this.ScreeningDataAccess.GetAsync();
        }

        public Task<Screening> GetAsync(IScreeningIdentity screening)
        {
            return this.ScreeningDataAccess.GetAsync(screening);
        }

        public async Task ValidateAsync(IScreeningContainer screeningContainer)
        {
            if (screeningContainer == null)
            {
                throw new ArgumentNullException(nameof(screeningContainer));
            }
            
            var screening = await this.GetBy(screeningContainer);

            if (screeningContainer.ScreeningId.HasValue && screening == null)
            {
                throw new InvalidOperationException($"Screening not found by id {screeningContainer.ScreeningId}");
            }
        }
        private Task<Screening> GetBy(IScreeningContainer departmentContainer)
        {
            return this.ScreeningDataAccess.GetByAsync(departmentContainer);
        }
    }
}