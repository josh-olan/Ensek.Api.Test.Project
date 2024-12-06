using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Extensions;
using Ensek.Api.Test.Project.Helpers;

namespace Ensek.Api.Test.Project.Services
{
    public class OrdersService : BaseService
    {
        public OrdersService(ApiHelper apiHelper) : base(apiHelper)
        {
        }

        public List<OrderCreatedResponse> GetAllOrders()
        {
            var (content, statusCode) = Client.GetRequest<List<OrderCreatedResponse>>(Endpoints.GetOrders);
            VerifyStatusCode(statusCode, 200);
            return content;
        }

        public OrderCreatedResponse GetOrder()
        {
            var (content, statusCode) = Client.GetRequest<OrderCreatedResponse>(Endpoints.GetOrderWithId);
            VerifyStatusCode(statusCode, 200);
            return content;
        }
    }
}
