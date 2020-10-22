using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using TheChuck.Services;
using System.Threading.Tasks;

namespace TheChuck.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {

        public ICommand SearchForJokeCommand { get; }
        public ICommand GetFavouritesCommand { get; }
        public ICommand SetCurrentJokeCommand { get; }
        public ICommand SaveAsFavouriteCommand { get; }

        private ObservableCollection<String> searchresult = new ObservableCollection<String>();
        private string currentJoke = "Här kommer ditt joke att visas";


        public SearchPageViewModel()
        {
            SearchForJokeCommand = new Command<string>(async (text) => await LoadJokes(text));
            GetFavouritesCommand = new Command(async () => await navigationService.GoToFavouritesPage());
            SetCurrentJokeCommand = new Command<string>( (joke) =>  SetCurrentJoke(joke));
            SaveAsFavouriteCommand = new Command(async () => await SaveFavourite());

        }

        public ObservableCollection<String> Searchresult { get => searchresult; }


        public async Task LoadJokes(string text)
        {
            searchresult.Clear();
            try
            {
                var response = await apiService.GetJokesFromSearchQuery(text);
                foreach (var result in response.Result)
                {
                    searchresult.Add(result.Value);
                    OnPropertyChanged();
                }
            }
            catch { }
            finally { }
        }

        public string CurrentJoke
        {
            get => currentJoke;
            set
            {
                if(currentJoke != value)
                {
                    currentJoke = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SetCurrentJoke(String joke)
        {
            CurrentJoke = joke;
        }


        public async Task SaveFavourite()
        {
            await App.Database.SaveFavouriteAsync(new Favourite
            {
                Value = currentJoke
            });

            Console.WriteLine("Testar om det läggs till: " + currentJoke);
        }
    }
}
