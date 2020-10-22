using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheChuck.Services
{
    public interface IDataBaseService
    {
        Task<List<Favourite>> GetFavouritesAsync();
        Task<int> SaveFavouriteAsync(Favourite favourite);
        Task<int> DeleteFavouritesAsync(Favourite favourite);
    }
}
