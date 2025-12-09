using Microsoft.AspNetCore.Identity;

namespace HrApi.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Avatar { get; set; } = string.Empty;
        public List<Interaction> Interactions { get; set; }
    }
}
