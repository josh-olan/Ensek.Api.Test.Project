using BoDi;
using Ensek.Api.Test.Project.Helpers;

namespace Ensek.Api.Test.Project.StepDefinitions
{
    [Binding]
    public class BaseStepDefinition
    {
        protected ApiHelper Client { get; private set; }

        protected IObjectContainer ObjectContainer { get; private set; }

        public BaseStepDefinition(IObjectContainer objectContainer) 
        {
            Client = objectContainer.Resolve<ApiHelper>();
            ObjectContainer = objectContainer;
        }
    }
}