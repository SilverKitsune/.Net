using System.ComponentModel.DataAnnotations;

namespace Cinemas.Client.Requests.Create
{
    public class MovieCreateDTO
    {
        //Название фильма
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        //Режиссер
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        //Дата премьеры
        [Required(ErrorMessage = "Date of premiere is required")]
        public string DateOfPremiere { get; set; }

        //Возрастное ограничение
        [Required(ErrorMessage = "Rating is required")]
        public int Age { get; set; }
        
        //public int? ScreeningId { get; set; }

    }
}