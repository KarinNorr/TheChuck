using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class FavouritePageViewModel : BaseViewModel
    {
        //favoriterna har också ett id ifall jag behöver för att ta bort dem sedan från favoritlistan
        private ObservableCollection<Favourite> favourites = new ObservableCollection<Favourite>();
        public ObservableCollection<Favourite> Favourites { get => favourites; }

        public List<Favourite> deleateFromFavourites = new List<Favourite>();

        public ICommand LoadFavouritesCommand { get; }
        public ICommand UpdateFavouritesCommand { get; }

        public FavouritePageViewModel()
        {
            //StartUpTestMock();
            LoadFavouritesCommand = new Command(async () => await LoadFavourites());
            UpdateFavouritesCommand = new Command(async () => await DeleteFromFavourites());
            LoadFavouritesCommand.Execute(this);
        }

        public async Task DeleteFromFavourites()
        {
            foreach (Favourite favvo in deleateFromFavourites)
            {
                var result = await App.Database.DeleteFavouritesAsync(favvo);
            }
            LoadFavouritesCommand.Execute(this);
        }

        public async Task LoadFavourites()
        {
            favourites.Clear();
            var result = await App.Database.GetFavouritesAsync();
            foreach (var favourite in result)
            {
                favourites.Add(favourite);
            }
        }


        private void StartUpTestMock()
        {
            Favourite testFavourite = new Favourite { Id = 1, Value = "Jag testar bara här " };
            Favourite testFavourite2 = new Favourite { Id = 2, Value = "Jag testar igen " };
            Favourite testFavourite3 = new Favourite { Id = 3, Value = "Och igen " };

            favourites.Add(testFavourite);
            favourites.Add(testFavourite2);
            favourites.Add(testFavourite3);

        }
    }
}
