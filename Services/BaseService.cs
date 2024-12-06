using Ensek.Api.Test.Project.Helpers;

namespace Ensek.Api.Test.Project.Services
{
    public abstract class BaseService
    {
        protected ApiHelper Client { get; set; }

        public BaseService(ApiHelper apiHelper)
        {
            Client = apiHelper;
        }

        protected static void VerifyStatusCode(int expected, int actual)
            => expected.Should().Be(actual);
    }
}