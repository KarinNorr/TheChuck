using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IApiService apiService{ get; set; } 
        public INavigationService navigationService { get; set; } 

        public BaseViewModel()
        {
            try
            {
                apiService = DependencyService.Get<IApiService>();
                navigationService = DependencyService.Get<INavigationService>();
            }
            catch
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
