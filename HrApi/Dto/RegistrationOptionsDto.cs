using System.Text.Json.Serialization;

namespace HrApi.Dto
{
    public class RegistrationOptionsDto
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

    }
}