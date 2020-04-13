using AutoMapper;
using Cinemas.Client.DTO.Read;
using Cinemas.Client.Requests.Create;
using Cinemas.Client.Requests.Update;
using Cinemas.Domain.Models;

namespace Cinemas.WebAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Cinema, Domain.Cinema>();
            this.CreateMap<DataAccess.Entities.Movie, Domain.Movie>();
            this.CreateMap<DataAccess.Entities.Screening, Domain.Screening>();
            this.CreateMap<Domain.Cinema, CinemaDTO>();
            this.CreateMap<Domain.Movie, MovieDTO>();
            this.CreateMap<Domain.Screening, ScreeningDTO>();
            
            this.CreateMap<CinemaCreateDTO, CinemaUpdateModel>();
            this.CreateMap<CinemaUpdateDTO, CinemaUpdateModel>();
            this.CreateMap<CinemaUpdateModel, DataAccess.Entities.Cinema>();
            
            this.CreateMap<MovieCreateDTO, MovieUpdateModel>();
            this.CreateMap<MovieUpdateDTO, MovieUpdateModel>();
            this.CreateMap<MovieUpdateModel, DataAccess.Entities.Movie>();
            
            this.CreateMap<ScreeningCreateDTO, ScreeningUpdateModel>();
            this.CreateMap<ScreeningUpdateDTO, ScreeningUpdateModel>();
            this.CreateMap<ScreeningUpdateModel, DataAccess.Entities.Screening>();
        }
    }
}