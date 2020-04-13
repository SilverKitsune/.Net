using System.ComponentModel.DataAnnotations;

namespace Cinemas.Client.Requests.Create
{
    public class ScreeningCreateDTO
    {
        
        //Информация о фильме
        public int? MovieId{ get; set; }
        
        //Время сеанса
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        
        //Дата сеанса
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public int? CinemaId { get; set; }
    }
}