using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinemas.DataAccess.Entities
{
        public partial class Cinema
    {
        public Cinema()
        {
            this.Screening = new HashSet<Screening>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Screening> Screening { get; set; }

        //Идентификатор
        public int Id { get; set; }
        
        //Название кинотеатра
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
        
    }
}