namespace Cinemas.Domain
{
    //Информация о кинотеатре
    public class Cinema
    {
        //Идентификатор
        public int Id { get; set; }
        
        //Название кинотеатра
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}