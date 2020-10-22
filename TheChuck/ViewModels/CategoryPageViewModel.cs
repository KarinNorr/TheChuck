using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class CategoryPageViewModel : BaseViewModel
    {

        private string category = string.Empty;
        private string joke = string.Empty;
        private bool isToggled = false; 
        //private Favourite jokeToMakeFavourite;

        public ICommand GetRandomFromCategoryCommand { get; }
        public ICommand SaveAsFavouriteCommand { get;  }


        public CategoryPageViewModel(string category)
        {
            this.category = category;
            GetRandomFromCategoryCommand = new Command(async () => await LoadRandomFromCategory(category));
            SaveAsFavouriteCommand = new Command(async () => await SaveFavourite());
            GetRandomFromCategoryCommand.Execute(this);
        }
        

        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }


        public bool IsToggled
        {
            get => isToggled;
            set
            {
                if(isToggled != value)
                {
                    isToggled = value;
                    OnPropertyChanged();
                }    
            }
        }

        public string Joke
        {
            get => joke;
            set
            {
                if (joke != value)
                {
                    joke = value;
                    OnPropertyChanged();
                }
            }
        }

        //public Favourite JokeToMakeFavourite
        //{
        //    get => JokeToMakeFavourite;
        //    set
        //    {
        //        if (jokeToMakeFavourite != null)
        //        {
        //            jokeToMakeFavourite = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}



        //Måste sätta IsToggle till false när en ny laddas

        public async Task LoadRandomFromCategory(string category)
        {
            try
            {
                var response = await apiService.GetRandomFromCategory(category);

                Favourite favourite = new Favourite();
                favourite.Value = response.Value;

                this.Joke = response.Value;
                this.IsToggled = false;
                //this.JokeToMakeFavourite = favourite;
                OnPropertyChanged();
                


            }
            catch {   }
            finally {   }
        }

        public async Task SaveFavourite()
        {
            await App.Database.SaveFavouriteAsync(new Favourite
            {
                Value = joke
            });

            IsToggled = true;
            Console.WriteLine("Testar om det läggs till: " + joke);
        }
    }
}
