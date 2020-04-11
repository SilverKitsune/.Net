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
    public class CinemaDataAccess : ICinemaDataAccess
    {
        private CinemaContext Context { get; }
        private IMapper Mapper { get; }

        public CinemaDataAccess(CinemaContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Cinema> InsertAsync(CinemaUpdateModel cinema)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Cinema>(cinema));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Cinema>(result.Entity);
        }

        public async Task<IEnumerable<Cinema>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Cinema>>(
                await this.Context.Cinema.Include(x => x.Screening).ToListAsync());

        }

        public async Task<Cinema> GetAsync(ICinemaIdentity cinema)
        {
            var result = await this.Get(cinema);

            return this.Mapper.Map<Cinema>(result);
        }

        public async Task<Cinema> UpdateAsync(CinemaUpdateModel cinema)
        {
            var existing = await this.Get(cinema);

            var result = this.Mapper.Map(cinema, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Cinema>(result);
        }

        public async Task<Cinema> GetByAsync(ICinemaContainer cinema)
        {
            return cinema.CinemaId.HasValue 
                ? this.Mapper.Map<Cinema>(await this.Context.Cinema.FirstOrDefaultAsync(x => x.Id == cinema.CinemaId)) 
                : null;
        }

        private async Task<Cinemas.DataAccess.Entities.Cinema> Get(ICinemaIdentity cinema)
        {
            //TODO
            if(cinema == null)
                throw new ArgumentNullException(nameof(cinema));
            return await this.Context.Cinema.Include(x => x.Screening).FirstOrDefaultAsync(x => x.Id == cinema.Id);
        }
    }
}