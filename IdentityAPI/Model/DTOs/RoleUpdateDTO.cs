namespace IdentityAPI.Model.DTOs
{
    public class RoleUpdateDTO
    {

        public string Description { get; set; }
        public List<int> UserIds { get; set; }

    }
}
