using Cinemas.Client.Requests.Create;

namespace Cinemas.Client.Requests.Update
{
    public class CinemaUpdateDTO : CinemaCreateDTO
    {
        public int Id { get; set; }
    }
}