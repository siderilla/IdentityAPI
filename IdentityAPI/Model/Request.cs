using Identity.Service.Model;

namespace IdentityAPI.Model
{
    public class Request
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

    }
}
