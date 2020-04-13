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
    [Route("api/cinema")]
    public class CinemaController
    {
        private ILogger<CinemaController> Logger { get; }
        private ICinemaCreateService CinemaCreateService { get; }
        private ICinemaGetService CinemaGetService { get; }
        private ICinemaUpdateService CinemaUpdateService { get; }
        private IMapper Mapper { get; }

        public CinemaController(ILogger<CinemaController> logger, IMapper mapper, ICinemaCreateService cinemaCreateService, ICinemaGetService cinemaGetService, ICinemaUpdateService cinemaUpdateService)
        {
            this.Logger = logger;
            this.CinemaCreateService = cinemaCreateService;
            this.CinemaGetService = cinemaGetService;
            this.CinemaUpdateService = cinemaUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<CinemaDTO> PutAsync(CinemaCreateDTO cinema)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CinemaCreateService.CreateAsync(this.Mapper.Map<CinemaUpdateModel>(cinema));

            return this.Mapper.Map<CinemaDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<CinemaDTO> PatchAsync(CinemaUpdateDTO cinema)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CinemaUpdateService.UpdateAsync(this.Mapper.Map<CinemaUpdateModel>(cinema));

            return this.Mapper.Map<CinemaDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CinemaDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<CinemaDTO>>(await this.CinemaGetService.GetAsync());
        }

        [HttpGet]
        [Route("{cinemaId}")]
        public async Task<CinemaDTO> GetAsync(int cinemaId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {cinemaId}");

            return this.Mapper.Map<CinemaDTO>(await this.CinemaGetService.GetAsync(new CinemaIdentityModel(cinemaId)));
        }
    }
}