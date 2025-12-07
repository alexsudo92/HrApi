using HrApi.Models.Passkey;
using System.Text.Json.Serialization;

namespace HrApi.Dto
{
    public class PasskeyDto<T>
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("passkeyResult")]
        public PasskeyResult<T> Result { get; set; }
    }
}