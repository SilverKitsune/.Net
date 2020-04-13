using System.ComponentModel.DataAnnotations;

namespace Cinemas.Client.Requests.Create
{
    public class CinemaCreateDTO
    {
        //Название кинотеатра
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //Адрес
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}