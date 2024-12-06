using Ensek.Api.Test.Project.Interfaces;
using Newtonsoft.Json;

namespace Ensek.Api.Test.Project.DTO.Response
{
    public class BaseResponse : IBaseResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}