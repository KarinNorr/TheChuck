using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace TheChuck.Services
{
    public class DataBaseService : IDataBaseService
    {

        readonly SQLiteAsyncConnection databaseConnection;

        public DataBaseService(string dbPath)
        {
            databaseConnection = new SQLiteAsyncConnection(dbPath);
            databaseConnection.CreateTableAsync<Favourite>().Wait();
        }

        public Task<List<Favourite>> GetFavouritesAsync()
        {
            return databaseConnection.Table<Favourite>().ToListAsync();
        }

        public Task<int> SaveFavouriteAsync(Favourite favourite)
        {
            return databaseConnection.InsertAsync(favourite);
        }

        public Task<int> DeleteFavouritesAsync(Favourite favourite)
        {
            try
            {
                if (favourite != null)
                {
                    return databaseConnection.DeleteAsync(favourite);
                }
            }
            catch {  }
            return null;
        }
    }
}
