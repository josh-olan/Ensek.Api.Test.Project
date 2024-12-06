using Ensek.Api.Test.Project.DTO.Request;
using Ensek.Api.Test.Project.DTO.Response;
using Ensek.Api.Test.Project.Extensions;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace Ensek.Api.Test.Project.Helpers
{
    public class ApiHelper
    {
        public RestClient Client { get; private set; }

        public ApiHelper()
        {
            var token = GetAccessToken();

            var options = new RestClientOptions(TestConfiguration.BaseUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };

            Client = new RestClient(options);
        }

        private string GetAccessToken()
        {
            using var client = new RestClient(TestConfiguration.BaseUrl);

            var response = client.PostRequest<LoginResource, LoginResponse>(Endpoints.Login, new LoginResource
            {
                Username = TestConfiguration.Username,
                Password = TestConfiguration.Password,
            }).content;

            response.Should().NotBeNull();
            return response!.AccessToken;
        }
    }
}