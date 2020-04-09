using Cinemas.Domain.Contracts;

namespace Cinemas.Domain.Models
{
    public class ScreeningUpdateModel : IScreeningIdentity, IMovieContainer, ICinemaContainer
    {
        public int Id { get; set; }
        
        //Время сеанса
        public string Time { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }
        
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
    }
}