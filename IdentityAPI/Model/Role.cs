using Identity.Service.Model;

namespace IdentityAPI.Model
{
    public class Role
    {

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
