using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinemas.DataAccess.Entities
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //идентификатор
        public int Id { get; set; }
        
        //Название фильма
        public string Title { get; set; }

        //Режиссер
        public string Director { get; set; }

        //Дата премьеры
        public string DateOfPremiere { get; set; }

        //Возрастное ограничение
        public int Age { get; set; }

        public int? ScreeningId => Screening.Id;
        public virtual Screening Screening { get; set; }
    }
}