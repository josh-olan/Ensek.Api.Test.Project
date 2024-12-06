using Newtonsoft.Json;

namespace Ensek.Api.Test.Project.DTO.Response
{
    public class OrderCreatedResponse
    {
        [JsonProperty("fuel")]
        public string Fuel { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}