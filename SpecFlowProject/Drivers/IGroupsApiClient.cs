using Refit;

namespace SpecFlowProject.Drivers
{
    //Read more about the Refit http client: https://github.com/reactiveui/refit
    //But you can also use another HTTP client instead if you want.
    public interface IGroupsApiClient
    {
        [Post("/groups")]
        public Task<GroupResponse> CreateGroup([Body] GroupRequest request);

        [Put("/groups/{id}")]
        public Task<GroupResponse> UpdateGroup(Guid id, [Body] GroupRequest request);

        [Get("/groups/{id}")]
        public Task<GroupResponse> GetGroup(Guid id);

        [Delete("/groups/{id}")]
        public Task DeleteGroup(Guid id);
    }

    public class GroupRequest
    {
        public string? Name { get; set; }
        public float Amps { get; set; }
    }

    public class GroupResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Amps { get; set; }
        public float UsedAmps { get; set; }
    }
}
