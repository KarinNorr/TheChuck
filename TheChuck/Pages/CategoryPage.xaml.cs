using System;
using System.Collections.Generic;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xamarin.Forms;

namespace TheChuck.Pages
{
    public partial class CategoryPage : ContentPage
    {
        CategoryPageViewModel viewModel; 

        public CategoryPage(string category)
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryPageViewModel(category);
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
