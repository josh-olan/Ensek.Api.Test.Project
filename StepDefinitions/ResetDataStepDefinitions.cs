using BoDi;
using Ensek.Api.Test.Project.Interfaces;
using Ensek.Api.Test.Project.Services;

namespace Ensek.Api.Test.Project.StepDefinitions
{
    [Binding]
    public class ResetDataStepDefinitions : BaseStepDefinition
    {
        private readonly TestDataService _testDataService;
        private IBaseResponse? _response;

        public ResetDataStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            _testDataService = new TestDataService(Client);
        }

        [When(@"I reset the test data")]
        public void GivenIResetTheTestData()
        {
            _response = _testDataService.ResetTestData();
        }

        [Then(@"the response message should be ""([^""]*)""")]
        public void ThenTheResponseMessageShouldBe(string message)
        {
            _response!.Message.Should().Be(message);
        }
    }
}