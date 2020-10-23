using System;
using System.Threading.Tasks;
using TheChuck.Services;

namespace TheChuck.Mocks
{
    public class NavigationServiceMock : INavigationService
    {
        public int GoToCategoryPageCall;
        public int GotToFavouritesPageCall;
        public int GoToSearchPageCall;


        public Task GoBack()
        {
            throw new NotImplementedException();
        }

        public async Task GoToCategoryPage(string category)
        {
            await Task.Run(() => { });
            GoToCategoryPageCall++;
        }

        public async Task GoToFavouritesPage()
        {
            await Task.Run(() => { });
            GotToFavouritesPageCall++;
        }

        public async Task GoToSearchPage()
        {
            await Task.Run(() => { });
            GoToSearchPageCall++;
        }
    }
}
