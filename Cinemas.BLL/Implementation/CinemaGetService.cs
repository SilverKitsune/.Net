using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;

namespace Cinemas.BLL.Implementation
{
    
    public class CinemaGetService : ICinemaGetService
    {
        private ICinemaDataAccess CinemaDataAccess { get; }
        
        public CinemaGetService(ICinemaDataAccess cinemaDataAccess)
        {
            this.CinemaDataAccess = cinemaDataAccess;
        }
        public Task<IEnumerable<Cinema>> GetAsync()
        {
            return this.CinemaDataAccess.GetAsync();
        }

        public Task<Cinema> GetAsync(ICinemaIdentity cinema)
        {
            return this.CinemaDataAccess.GetAsync(cinema);
        }

        public async Task ValidateAsync(ICinemaContainer cinemaContainer)
        {
            if (cinemaContainer == null)
            {
                throw new ArgumentNullException(nameof(cinemaContainer));
            }
            
            var cinema = await this.GetBy(cinemaContainer);

            if (cinemaContainer.CinemaId.HasValue && cinema == null)
            {
                throw new InvalidOperationException($"Cinema not found by id {cinemaContainer.CinemaId}");
            }
        }
        private async Task<Cinema> GetBy(ICinemaContainer cinemaContainer)
        {
            return await this.CinemaDataAccess.GetByAsync(cinemaContainer);
        }
    }
}