using Microsoft.AspNetCore.Identity;

namespace HrApi.Models
{
    public class User : IdentityUser<Guid>
    {
        public Guid Avatar { get; set; }
    }
}
