using BoDi;
using Ensek.Api.Test.Project.Helpers;

namespace Ensek.Api.Test.Project.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeTestRun] 
        public static void BeforeTestRun(TestContext testContext, IObjectContainer objectContainer)
        {
            // Load test configurations
            TestConfiguration.LoadConfigurations(testContext);

            // Init API client
            var client = new ApiHelper();

            // Register the API client to be used for context injection
            objectContainer.RegisterInstanceAs(client);
        }
    }
}