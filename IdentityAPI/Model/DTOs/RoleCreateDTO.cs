namespace IdentityAPI.Model.DTOs
{
    public class RoleCreateDTO
    {
        public string Description { get; set; }
        public List<int> UserIds { get; set; }


    }
}
