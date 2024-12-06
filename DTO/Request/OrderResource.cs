using Newtonsoft.Json;

namespace Ensek.Api.Test.Project.DTO.Request
{
    public class OrderResource
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
    }
}