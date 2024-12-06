using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Extensions;
using Ensek.Api.Test.Project.Helpers;

namespace Ensek.Api.Test.Project.Services
{
    public class TestDataService : BaseService
    {
        public TestDataService(ApiHelper apiHelper) : base(apiHelper) { }

        public BaseResponse ResetTestData()
        {
            return Client.PostRequest<BaseResponse>(Endpoints.ResetData).content;
        }
    }
}