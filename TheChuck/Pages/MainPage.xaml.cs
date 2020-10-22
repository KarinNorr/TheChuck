using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChuck.ViewModels;
using Xamarin.Forms;

namespace TheChuck
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        void HistoryView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var category = e.Item as string;
            if (category != null)
            {
                viewModel.GoToCategoryCommand.Execute(category);

            }

        }
    }
}
