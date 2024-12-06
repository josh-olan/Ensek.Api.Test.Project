using Newtonsoft.Json;

namespace Ensek.Api.Test.Project.DTO.Response
{
    public class LoginResponse : BaseResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}