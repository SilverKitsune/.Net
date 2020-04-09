using Cinemas.Domain.Contracts;

namespace Cinemas.Domain
{
    //Информация о сеансе
    public class Screening : ICinemaContainer, IMovieContainer
    {
        //идентификатор
        public int Id { get; set; }
        
        //Информация о фильме
        public Movie Movie{ get; set; }
        
        //Время сеанса
        public string Time { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }

        public Cinema Cinema { get; set; }
        
        public int? CinemaId => Cinema.Id;

        public int? MovieId => Movie.Id;
    }
}