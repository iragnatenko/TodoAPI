using System.Text.Json.Serialization;

namespace BlazorAppTodoAPI.Models
{
    public class TokenRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = String.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = String.Empty;
    }
}
