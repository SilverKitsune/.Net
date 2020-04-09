using Cinemas.Domain.Contracts;

namespace Cinemas.Domain.Models
{
    public class CinemaUpdateModel : ICinemaIdentity
    {
        public int Id { get; set; }
        
        //Название кинотеатра
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}