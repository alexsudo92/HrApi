using System.ComponentModel.DataAnnotations;

namespace HrApi.Dto
{
    public record RegisterDto(
        [Required(AllowEmptyStrings = false)] string Username,
        [Required(AllowEmptyStrings = false)] string Email,
        [Required(AllowEmptyStrings = false)] string Password,
        [Required(AllowEmptyStrings = false)] string Phone);
}
