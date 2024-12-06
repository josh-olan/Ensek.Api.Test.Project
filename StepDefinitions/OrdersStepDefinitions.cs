using BoDi;
using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Services;

namespace Ensek.Api.Test.Project.StepDefinitions
{
    [Binding]
    public class OrdersStepDefinitions : BaseStepDefinition
    {
        private readonly OrdersService _ordersService;
        private List<OrderCreatedResponse>? _allOrders;

        public OrdersStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            _ordersService = new OrdersService(Client);
        }

        [Then(@"all orders are added to the orders list")]
        public void ThenAllOrdersAreAddedToTheOrdersList()
        {
            _allOrders = _ordersService.GetAllOrders();

            // Get created orders
            var createdOrders = ObjectContainer.Resolve<List<OrderCreatedResponse>>();

            createdOrders.ForEach(createdOrder =>
            {
                var foundOrder = _allOrders.FirstOrDefault(order => createdOrder.Id == order.Id);

                foundOrder.Should().NotBeNull($"Order with energy type => {createdOrder.Fuel}" +
                    $" and order ID => {createdOrder.Id} was not found");

                foundOrder!.Fuel.Should().Be(createdOrder.Fuel, $"Energy type does not match!\n" +
                    $"Order ID => {createdOrder.Id}. Fuel => {createdOrder.Fuel}");

                foundOrder!.Quantity.Should().Be(createdOrder.Quantity, $"Quantity does not match!\n" +
                    $"Order ID => {createdOrder.Id}. Fuel => {createdOrder.Fuel}");
            });
        }

        [When(@"I get all orders")]
        public void WhenIGetAllOrders()
        {
            _allOrders = _ordersService.GetAllOrders();
        }

        [Then(@"I can get the number of orders created before today")]
        public void ThenICanGetTheNumberOfOrdersCreatedBeforeToday()
        {
            var count = _allOrders!.Where(order => order.Time < DateTime.Today).Count();
            Console.WriteLine($"Count of orders created before today => {count}");
            count.Should().BeGreaterThan(0);
        }
    }
}