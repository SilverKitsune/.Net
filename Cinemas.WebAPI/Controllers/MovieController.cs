using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinemas.BLL.Contracts;
using Cinemas.Client.DTO.Read;
using Cinemas.Client.Requests.Create;
using Cinemas.Client.Requests.Update;
using Cinemas.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Cinemas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private ILogger<MovieController> Logger { get; }
        private IMovieCreateService MovieCreateService { get; }
        private IMovieGetService MovieGetService { get; }
        private IMovieUpdateService MovieUpdateService { get; }
        private IMapper Mapper { get; }

        public MovieController(ILogger<MovieController> logger, IMapper mapper, IMovieCreateService movieCreateService, IMovieGetService movieGetService, IMovieUpdateService movieUpdateService)
        {
            this.Logger = logger;
            this.MovieCreateService = movieCreateService;
            this.MovieGetService = movieGetService;
            this.MovieUpdateService = movieUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<MovieDTO> PutAsync(MovieCreateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.MovieCreateService.CreateAsync(this.Mapper.Map<MovieUpdateModel>(movie));

            return this.Mapper.Map<MovieDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<MovieDTO> PatchAsync(MovieUpdateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.MovieUpdateService.UpdateAsync(this.Mapper.Map<MovieUpdateModel>(movie));

            return this.Mapper.Map<MovieDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MovieDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<MovieDTO>>(await this.MovieGetService.GetAsync());
        }

        [HttpGet]
        [Route("{movieId}")]
        public async Task<MovieDTO> GetAsync(int movieId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {movieId}");

            return this.Mapper.Map<MovieDTO>(await this.MovieGetService.GetAsync(new MovieIdentityModel(movieId)));
        }
    }
}