using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheChuck.Services;

namespace TheChuck.Mocks
{
    public class DataBaseMock : IDataBaseService
    {
        public int SaveFavouriteCallCounter;
        public int DeleteFavouriteCallCounter;
        public int GetFavouritesCallCounter;


        public Task<int> DeleteFavouritesAsync(Favourite favourite)
        {
            DeleteFavouriteCallCounter++;
            return null;
        }

        public Task<List<Favourite>> GetFavouritesAsync()
        {
            GetFavouritesCallCounter++;
            return null;
        }

        public Task<int> SaveFavouriteAsync(Favourite favourite)
        {
            SaveFavouriteCallCounter++;
            return null;
        }
    }
}
