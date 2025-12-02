using System.Text.Json.Serialization;

namespace HrApi.Models.Passkey
{
    public class AssertionResponse
    {
        [JsonPropertyName("authenticatorData")]
        public string AuthenticatorData { get; set; }

        [JsonPropertyName("clientDataJSON")]
        public string ClientDataJSON { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        [JsonPropertyName("userHandle")]
        public string UserHandle { get; set; }
    }
}