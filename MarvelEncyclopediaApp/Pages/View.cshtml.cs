using MarvelApp.Helpers;
using MarvelApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace MarvelApp.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        public SearchResult? SearchResult;

        public ViewModel(IConfiguration configuration, IHelper helper)
        {
            _configuration = configuration;
            _helper = helper;
        }

        public async Task OnGet(string selectedOption, string id)
        {
            RestRequest request = new();
            RestResponse response = new();

            switch (selectedOption)
            {
                case "characters":
                    request = new("characters/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
                case "comics":
                    request = new("comics/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
                case "events":
                    request = new("events/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
                case "creators":
                    request = new("creators/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
                case "series":
                    request = new("series/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
                case "stories":
                    request = new("stories/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
                    response = await _helper.SendRequestToApiAsync(request);

                    if (response.IsSuccessful)
                    {
                        SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                    }
                    break;
            }          
        }
    }
}
