namespace Ensek.Api.Test.Project
{
    public static class Endpoints
    {
        public const string Login = "/ENSEK/login";
        public const string ResetData = "/ENSEK/reset";
        public const string GetOrderWithId = "/ENSEK/orders/{orderId}";
        public const string UpdateOrder = "/ENSEK/orders/{orderId}";
        public const string DeleteOrder = "/ENSEK/orders/{orderId}";
        public const string GetOrders = "/ENSEK/orders";
        public const string GetEnergyTypes = "/ENSEK/energy";
        public const string PurchaseEnergyUnits = "/ENSEK/buy/{id}/{quantity}";
    }
}
