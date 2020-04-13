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
    [Route("api/screening")]
    public class ScreeningController
    {
        private ILogger<ScreeningController> Logger { get; }
        private IScreeningCreateService ScreeningCreateService { get; }
        private IScreeningGetService ScreeningGetService { get; }
        private IScreeningUpdateService ScreeningUpdateService { get; }
        private IMapper Mapper { get; }

        public ScreeningController(ILogger<ScreeningController> logger, IMapper mapper, IScreeningCreateService screeningCreateService, IScreeningGetService screeningGetService, IScreeningUpdateService screeningUpdateService)
        {
            this.Logger = logger;
            this.ScreeningCreateService = screeningCreateService;
            this.ScreeningGetService = screeningGetService;
            this.ScreeningUpdateService = screeningUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ScreeningDTO> PutAsync(ScreeningCreateDTO screening)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ScreeningCreateService.CreateAsync(this.Mapper.Map<ScreeningUpdateModel>(screening));

            return this.Mapper.Map<ScreeningDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ScreeningDTO> PatchAsync(ScreeningUpdateDTO screening)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ScreeningUpdateService.UpdateAsync(this.Mapper.Map<ScreeningUpdateModel>(screening));

            return this.Mapper.Map<ScreeningDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ScreeningDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ScreeningDTO>>(await this.ScreeningGetService.GetAsync());
        }

        [HttpGet]
        [Route("{screeningId}")]
        public async Task<ScreeningDTO> GetAsync(int screeningId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {screeningId}");

            return this.Mapper.Map<ScreeningDTO>(await this.ScreeningGetService.GetAsync(new ScreeningIdentityModel(screeningId)));
        }
    }
}