using System.Text.Json.Serialization;

namespace HrApi.Models.Passkey
{
    public class PasskeyOptionsDto
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

    }
}