using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheChuck.Services
{
    public interface IApiService
    {
        Task<DTOJoke> GetRandom();

        Task<DTOJoke> GetRandomFromCategory(string category);

        Task <List<String>> GetCategories();

        Task<DTOResultFromQuery> GetJokesFromSearchQuery(string searchresult);
    }
}
