namespace Cinemas.Client.DTO.Read
{
    public class ScreeningDTO
    {
        //идентификатор
        public int Id { get; set; }

        //Время сеанса
        public string Time { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }

        public CinemaDTO Cinema { get; set; }
        
        public MovieDTO Movie{ get; set; }
    }
}