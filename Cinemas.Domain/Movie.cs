﻿using Cinemas.Domain.Contracts;

namespace Cinemas.Domain
{
    //Информация о фильме
    public class Movie : IScreeningContainer
    {
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
        public Screening Screening { get; set; }
    }
}