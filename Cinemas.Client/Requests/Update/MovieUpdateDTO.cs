using Cinemas.Client.Requests.Create;

namespace Cinemas.Client.Requests.Update
{
    public class MovieUpdateDTO : MovieCreateDTO
    {
        public int Id { get; set; }
    }
}