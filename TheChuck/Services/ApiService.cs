using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheChuck.Services
{
    public class ApiService : IApiService
    {
        public ApiService()
        {
        }

        public async Task<List<string>> GetCategories()
        {
            var data = await Get("https://api.chucknorris.io/jokes/categories");
            return JsonConvert.DeserializeObject<List<string>>(data);
        }

        public async Task<DTOResultFromQuery> GetJokesFromSearchQuery(string searchresult)
        {
            var data = await Get("https://api.chucknorris.io/jokes/search?query=" + searchresult);
            return JsonConvert.DeserializeObject<DTOResultFromQuery>(data);
        }

        public Task<DTOJoke> GetRandom()
        {
            throw new NotImplementedException();
        }

        //Stämmer den DTO som jag har gjort med det sökresultat som kommer tillbaks
        public async Task<DTOJoke> GetRandomFromCategory(string category)
        {
            var data = await Get("https://api.chucknorris.io/jokes/random?category=" + category);
            return JsonConvert.DeserializeObject<DTOJoke>(data);
        }

        protected async Task<string> Get(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";
        }

    }
}
