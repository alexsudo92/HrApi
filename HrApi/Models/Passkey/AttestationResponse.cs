using System.Text.Json.Serialization;

namespace HrApi.Models.Passkey
{
    public class AttestationResponse
    {
        [JsonPropertyName("attestationObject")]
        public string AttestationObject { get; set; }

        [JsonPropertyName("authenticatorData")]
        public string AuthenticatorData { get; set; }

        [JsonPropertyName("clientDataJSON")]
        public string ClientDataJSON { get; set; }

        [JsonPropertyName("publicKey")]
        public string PublicKey { get; set; }

        [JsonPropertyName("publicKeyAlgorithm")]
        public int PublicKeyAlgorithm { get; set; }

        [JsonPropertyName("transports")]
        public List<string> Transports { get; set; }
    }
}