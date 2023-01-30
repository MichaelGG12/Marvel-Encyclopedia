using MarvelApp.Helpers;
using MarvelApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace MarvelApp.Pages
{
    public class EventModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        public SearchResult? SearchResult;
        
        public EventModel(IConfiguration configuration, IHelper helper)
        {
            _configuration = configuration;
            _helper = helper;
        }
        
        public async Task OnGet(string id)
        {
            RestRequest request = new("events/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
            }
        }
    }
}
