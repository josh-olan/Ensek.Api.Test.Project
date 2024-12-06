namespace Ensek.Api.Test.Project.Helpers
{
    public static class TestConfiguration
    {
        public static string BaseUrl { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }

        public static void LoadConfigurations(TestContext testContext)
        {
            BaseUrl = testContext.Properties["baseUrl"].ToString();
            Username = testContext.Properties["username"].ToString();
            Password = testContext.Properties["password"].ToString();
        }
    }
}