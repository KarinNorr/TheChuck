using System;
using System.Collections.Generic;
using TheChuck.ViewModels;
using Xamarin.Forms;

namespace TheChuck.Pages
{
    public partial class SearchPage : ContentPage
    {
        CatygoryPageViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CatygoryPageViewModel();
        }

        void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string joke = e.Item as string;
            viewModel.SetCurrentJokeCommand.Execute(joke);
        }


        void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            
            if (e.Value == true)
            {
                viewModel.SaveAsFavouriteCommand.Execute(this);
            }
        }
    }
}
