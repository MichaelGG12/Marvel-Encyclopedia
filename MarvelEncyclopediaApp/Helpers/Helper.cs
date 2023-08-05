using RestSharp;

namespace MarvelApp.Helpers
{
    public interface IHelper
    {
        Task<RestResponse> SendRequestToApiAsync(RestRequest request);
    }

    public class Helper : IHelper
    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RestResponse> SendRequestToApiAsync(RestRequest request)
        {
            RestClient restClient = new RestClient(_configuration["ApiSettings:ApiUrl"]);
            RestResponse response = await restClient.ExecuteAsync(request);
            return response;
        }
    }
}
