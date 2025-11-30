using System.Text.Json.Serialization;

namespace HrApi.Models.Passkey
{
    public class PasskeyResult
    {
        [JsonPropertyName("authenticatorAttachment")]
        public string AuthenticatorAttachment { get; set; }

        [JsonPropertyName("clientExtensionResults")]
        public ClientExtensionResults ClientExtensionResults { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rawId")]
        public string RawId { get; set; }

        [JsonPropertyName("response")]
        public Response Response { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}