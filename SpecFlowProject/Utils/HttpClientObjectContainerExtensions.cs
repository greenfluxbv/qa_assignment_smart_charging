using BoDi;
using Newtonsoft.Json;
using Refit;

namespace SpecFlowProject.Utils
{
    public static class HttpClientObjectContainerExtensions
    {
        private static readonly HttpClientHandler HttpClientHandler = new() { AllowAutoRedirect = false };

        public static void AddRefitClient<T>(this IObjectContainer container, Action<System.Net.Http.HttpClient> action)
        {
            var httpClient = new HttpClient(HttpClientHandler)
            {
                Timeout = TimeSpan.FromMinutes(3)
            };
            action(httpClient);
            var refitSettings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    }
                )
            };
            var client = RestService.For<T>(httpClient, refitSettings);
            container.RegisterInstanceAs(client, typeof(T));
        }
    }
}
