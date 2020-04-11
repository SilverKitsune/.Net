using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemas.DataAccess.Context;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;
using Cinemas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Cinemas.DataAccess.Implementations
{
    public class ScreeningDataAccess : IScreeningDataAccess
    {
        private CinemaContext Context { get; }
        private IMapper Mapper { get; }

        public ScreeningDataAccess(CinemaContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Screening> InsertAsync(ScreeningUpdateModel screening)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Screening>(screening));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Screening>(result.Entity);
        }

        public async Task<IEnumerable<Screening>> GetAsync()
        {
            //TODO
            return this.Mapper.Map<IEnumerable<Screening>>(await this.Context.Screening.Include(x => x.Cinema).Include(x=>x.Movie).ToListAsync());
        }

        public async Task<Screening> GetAsync(IScreeningIdentity screeningId)
        {

            var result = await this.Get(screeningId);
            return this.Mapper.Map<Screening>(result);
        }
        
        private async Task<Cinemas.DataAccess.Entities.Screening> Get(IScreeningIdentity screeningId)
        {
            //TODO
            if (screeningId == null)
                throw new ArgumentNullException(nameof(screeningId));
            return await this.Context.Screening.Include(x => x.Cinema).Include(x=>x.Movie).FirstOrDefaultAsync(x => x.Id == screeningId.Id);
            
        }

        public async Task<Screening> UpdateAsync(ScreeningUpdateModel screening)
        {
            var existing = await this.Get(screening);

            var result = this.Mapper.Map(screening, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Screening>(result);
        }

        public async Task<Screening> GetByAsync(IScreeningContainer screening)
        {
            return screening.ScreeningId.HasValue 
                ? this.Mapper.Map<Screening>(await this.Context.Screening.FirstOrDefaultAsync(x => x.Id == screening.ScreeningId)) 
                : null;
        }
    }
}