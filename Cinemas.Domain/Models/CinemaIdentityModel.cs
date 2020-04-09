using Cinemas.Domain.Contracts;

namespace Cinemas.Domain.Models
{
    public class CinemaIdentityModel : ICinemaIdentity
    {
        public int Id { get; }

        public CinemaIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}