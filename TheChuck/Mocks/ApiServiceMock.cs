using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheChuck.Services;

namespace TheChuck.Mocks
{
    public class ApiServiceMock : IApiService
    {
        public int JokeFromqueryCallCount; 

        public async Task<List<string>> GetCategories()
        {
            await Task.Run(() => { });
            List<String> categorysMock = new List<string>();

            categorysMock.Add("HomeParty");
            categorysMock.Add("Animals");
            categorysMock.Add("Food");
            categorysMock.Add("Activitys");

            return categorysMock;
        }

        public async Task<DTOResultFromQuery> GetJokesFromSearchQuery(string searchresult)
        {
            JokeFromqueryCallCount++;
            await Task.Run(() => { });
            return null;
            
        }


        public Task<DTOJoke> GetRandom()
        {
            throw new NotImplementedException();
        }

        public async Task<DTOJoke> GetRandomFromCategory(string category)
        {
            await Task.Run(() => { });

            return new DTOJoke()
            {
                IconUrl = string.Empty,
                Id = "testId",
                Url = "testUrl",
                Value = "Idag är en tråkig dag!"
            };
        }
    }
}
