using BoDi;
using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Services;

namespace Ensek.Api.Test.Project.StepDefinitions
{
    [Binding]
    public class EnergyStepDefinitions : BaseStepDefinition
    {
        private readonly EnergyService _energyService;
        private Dictionary<string, FuelResponse>? _energyTypes; 

        public EnergyStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            _energyService = new EnergyService(Client);
        }

        [Given(@"I get the types of fuel")]
        public void GivenIGetTheTypesOfFuel()
        {
            _energyTypes = _energyService.GetEnergyTypes();
        }

        [When(@"I buy (.*) quantities of each fuel")]
        public void WhenICanBuyQuantityOfEachFuel(int number)
        {
            var createdOrders = _energyTypes!.Select(type =>
            {
                return _energyService.PurchaseEnergy(type.Key, type.Value.EnergyId, number);
            }).Where(order => order != null).ToList();

            ObjectContainer.RegisterInstanceAs(createdOrders);
        }
    }
}