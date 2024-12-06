using Newtonsoft.Json;

namespace Ensek.Api.Test.Project.DTO.Request
{
    public class LoginResource
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}