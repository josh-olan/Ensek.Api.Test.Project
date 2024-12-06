using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Extensions;
using Ensek.Api.Test.Project.Helpers;
using System.Text.RegularExpressions;

namespace Ensek.Api.Test.Project.Services
{
    public class EnergyService : BaseService
    {
        private const string OrderIdPattern = "[0-9a-zA-Z]{8}[-][0-9a-zA-Z]{4}[-][0-9a-zA-Z]{4}" +
            "[-][0-9a-zA-Z]{4}[-][0-9a-zA-Z]{12}";

        public EnergyService(ApiHelper apiHelper) : base(apiHelper) { }

        public Dictionary<string, FuelResponse> GetEnergyTypes()
        {
            var (content, statusCode) = Client.GetRequest<Dictionary<string, FuelResponse>>(Endpoints.GetEnergyTypes);
            VerifyStatusCode(statusCode, 200);
            return content;
        }

        public OrderCreatedResponse? PurchaseEnergy(string fuel, int id, int quantity)
        {
            var (content, statusCode) = Client.PutRequest<BaseResponse>(Endpoints.PurchaseEnergyUnits, 
                new Dictionary<string, string>() 
            {
                { "id", id.ToString() },
                { "quantity", quantity.ToString() }
            });
            VerifyStatusCode(statusCode, 200);

            var orderId = GetMatch(OrderIdPattern, content.Message);

            if (orderId == null)
            {
                // If orderId is not found then log warning
                Console.WriteLine($"Order could not be created for => '{fuel}'.\n" +
                    $"$Message => {content.Message}");
                return null;
            }

            // return created order
            var createdOrder = new OrderCreatedResponse
            {
                Fuel = fuel,
                Id = orderId!,
                Quantity = quantity
            };

            return createdOrder;
        }

        public string? GetMatch(string pattern, string sentence)
        {
            var reg = new Regex(pattern);

            // Match the regular expression pattern against a text string
            Match match = reg.Match(sentence);

            return match.Success ? match.Value : null;
        }
    }
}