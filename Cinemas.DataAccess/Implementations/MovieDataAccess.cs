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
    public class MovieDataAccess : IMovieDataAccess
    {
        private CinemaContext Context { get; }
        private IMapper Mapper { get; }

        public MovieDataAccess(CinemaContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Movie> InsertAsync(MovieUpdateModel movie)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Movie>(movie));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Movie>(result.Entity);
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Movie>>(
                await this.Context.Movie.Include(x => x.Screening).ToListAsync());

        }

        public async Task<Movie> GetAsync(IMovieIdentity movie)
        {
            var result = await this.Get(movie);

            return this.Mapper.Map<Movie>(result);
        }

        public async Task<Movie> UpdateAsync(MovieUpdateModel movie)
        {
            var existing = await this.Get(movie);

            var result = this.Mapper.Map(movie, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Movie>(result);
        }

        public async Task<Movie> GetByAsync(IMovieContainer movie)
        {
            return movie.MovieId.HasValue 
                ? this.Mapper.Map<Movie>(await this.Context.Movie.FirstOrDefaultAsync(x => x.Id == movie.MovieId)) 
                : null;
        }

        private async Task<Cinemas.DataAccess.Entities.Movie> Get(IMovieIdentity movie)
        {
            if(movie == null)
                throw new ArgumentNullException(nameof(movie));
            return await this.Context.Movie.Include(x => x.Screening).FirstOrDefaultAsync(x => x.Id == movie.Id);
        }
    }
}