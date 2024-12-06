using Ensek.Api.Test.Project.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace Ensek.Api.Test.Project.Extensions
{
    public static class ApiHelperExtensions
    {
        public static (TResponse content, int statusCode) PostRequest<TRequest, TResponse>(this ApiHelper helper, 
            string resource, TRequest payload)
        {
            return ExecuteAndParseResponse<TResponse>(helper, Post(resource, payload));
        }

        // Ideally would be in its own class
        public static (TResponse content, int statusCode) PostRequest<TRequest, TResponse>(this RestClient restClient, 
            string resource, TRequest payload)
        {
            return ExecuteAndParseResponse<TResponse>(restClient, Post(resource, payload));
        }

        public static (T content, int statusCode) PostRequest<T>(this ApiHelper helper, string resource)
        {
            var request = new RestRequest(resource, Method.Post);
            return ExecuteAndParseResponse<T>(helper, request);
        }

        public static (T content, int statusCode) GetRequest<T>(this ApiHelper helper, string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            return ExecuteAndParseResponse<T>(helper, request);
        }

        public static (T content, int statusCode) PutRequest<T>(this ApiHelper helper, string resource, 
            Dictionary<string, string> args)
        {
            var request = new RestRequest(resource, Method.Put);
            args.ToList().ForEach(param => request.AddUrlSegment(param.Key, param.Value));
            return ExecuteAndParseResponse<T>(helper, request);
        }

        private static RestRequest Post<T>(string resource, T payload)
        {
            var request = new RestRequest(resource, Method.Post);
            var body = JsonConvert.SerializeObject(payload, Formatting.Indented);

            request.AddJsonBody(body);
            return request;
        }

        private static (T content, int statusCode) ExecuteAndParseResponse<T>(ApiHelper helper, RestRequest request)
        {
            return ExecuteAndParseResponse<T>(helper.Client, request);
        }

        private static (T content, int statusCode) ExecuteAndParseResponse<T>(RestClient restClient, RestRequest request)
        {
            request.AddHeader("Accept", "application/json");
            var response = restClient.Execute(request);
            return (JsonConvert.DeserializeObject<T>(response.Content!)!, (int)response.StatusCode);
        }
    }
}