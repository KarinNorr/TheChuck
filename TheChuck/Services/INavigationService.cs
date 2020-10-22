using System;
using System.Threading.Tasks;

namespace TheChuck.Services
{
    public interface INavigationService
    {
        Task GoToCategoryPage(string category);
        Task GoToSearchPage();
        Task GoBack();
        Task GoToFavouritesPage();
    }
}
