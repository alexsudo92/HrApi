using System.ComponentModel.DataAnnotations;

namespace HrApi.Dto
{
    public record LoginDto(
        [Required(AllowEmptyStrings = false)] string Email,
        [Required(AllowEmptyStrings = false)] string Password);
}
