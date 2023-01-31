using MarvelApp.Helpers;
using MarvelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace MarvelApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;

        public SearchResult? SearchResult;

        public IndexModel(IConfiguration configuration, IHelper helper)
        {
            _configuration = configuration;
            _helper = helper;
        }

        public async Task<ObjectResult> OnGetListsOfCharacters(string givenTerm)
        {
            RestRequest request = new("characters?nameStartsWith=" + givenTerm + "&" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public async Task<ObjectResult> OnGetListsOfComics(string givenTerm)
        {
            RestRequest request = new("comics?titleStartsWith=" + givenTerm + "&" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public async Task<ObjectResult> OnGetListsOfEvents(string givenTerm)
        {
            RestRequest request = new("events?nameStartsWith=" + givenTerm + "&" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public async Task<ObjectResult> OnGetListsOfCreators(string givenTerm)
        {
            RestRequest request = new("creators?nameStartsWith=" + givenTerm + "&" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public async Task<ObjectResult> OnGetListsOfSeries(string givenTerm)
        {
            RestRequest request = new("series?titleStartsWith=" + givenTerm + "&" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public async Task<ObjectResult> OnGetListsOfStories(string givenTerm)
        {
            RestRequest request = new("series?" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
                return new ObjectResult(new { data = SearchResult.Data.Results });
            }
            return new ObjectResult(new { status = "fail" });
        }
    }
}