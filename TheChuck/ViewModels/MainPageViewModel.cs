using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private string welcome = "Welcome to Chuck!";
        private ObservableCollection<String> categories = new ObservableCollection<String>();

        public ICommand GoToSearchPageCommand { get; }
        public ICommand LoadCommand { get;  }
        public ICommand GoToCategoryCommand { get; }

        public MainPageViewModel()
        {
            GoToSearchPageCommand = new Command(async () => await navigationService.GoToSearchPage());
            LoadCommand = new Command(async () => await LoadCategories());
            GoToCategoryCommand = new Command<string>(async (category) => await navigationService.GoToCategoryPage(category));
            LoadCommand.Execute(this);
        }

        public ObservableCollection<String> Categories { get => categories; }

        public string Welcome
        {
            get => welcome;
            set
            {
                if (welcome != value)
                {
                    welcome = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task LoadCategories()
        {
            try
            {
                var response = await apiService.GetCategories();
                Console.WriteLine(response);
                foreach (var category in response)
                {
                    categories.Add(category);
                    OnPropertyChanged();
                }
            }
            catch { }
            finally { }
        }
    }
}
