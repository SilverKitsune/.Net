using Cinemas.Domain.Contracts;

namespace Cinemas.Domain.Models
{
    public class ScreeningIdentityModel : IScreeningIdentity
    {
        public int Id { get; }

        public ScreeningIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}