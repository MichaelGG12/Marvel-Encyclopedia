using MarvelApp.Helpers;
using MarvelApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace MarvelApp.Pages
{
    public class HeroModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        public SearchResult? SearchResult;

        public HeroModel(IConfiguration configuration, IHelper helper)
        {
            _configuration = configuration;
            _helper = helper;
        }

        public async Task OnGet(string id)
        {
            RestRequest request = new("characters/" + id + "?" + _configuration["ApiSettings:ApiKey"]);
            RestResponse response = await _helper.SendRequestToApiAsync(request);

            if (response.IsSuccessful)
            {
                SearchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content);
            }
        }
    }
}
