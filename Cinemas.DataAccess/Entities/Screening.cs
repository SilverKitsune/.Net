﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinemas.DataAccess.Entities
{
    public class Screening
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //идентификатор
        public int Id { get; set; }
        
        //Время сеанса
        public string Time { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }
        
        public int? CinemaId { get; set; }

        public int? MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}