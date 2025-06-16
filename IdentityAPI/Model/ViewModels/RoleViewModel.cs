namespace IdentityAPI.Model.ViewModels
{
    public class RoleViewModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public List<int> UserIds { get; set; }

    }
}
