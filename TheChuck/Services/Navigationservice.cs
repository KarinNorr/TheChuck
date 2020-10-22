using System;
using System.Threading.Tasks;
using TheChuck.Pages;
using Xamarin.Forms;

namespace TheChuck.Services
{
    public class Navigationservice : INavigationService
    {
        private Page page => Xamarin.Forms.Application.Current.MainPage;

        public async Task GoBack()
        {
            await page.Navigation.PopAsync();
        }

        public async Task GoToCategoryPage(String category)
        {
            await page.Navigation.PushAsync(new CategoryPage(category));
        }

        public async Task GoToSearchPage()
        {
            await page.Navigation.PushAsync(new SearchPage());
        }

        public async Task GoToFavouritesPage()
        {
            await page.Navigation.PushAsync(new FavouritePage());
        }
    }
}
