namespace Cinemas.Client.DTO.Read
{
    public class MovieDTO
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
        
    }
}