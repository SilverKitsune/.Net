using Cinemas.Domain.Contracts;

namespace Cinemas.Domain.Models
{
    public class MovieIdentityModel : IMovieIdentity
    {
        public int Id { get; }

        public MovieIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}