using Microsoft.AspNetCore.Identity;

namespace HrApi.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; }
        public Guid Avatar { get; set; }
    }
}
