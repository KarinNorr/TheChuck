using System;
using System.Collections.Generic;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xamarin.Forms;

namespace TheChuck.Pages
{
    public partial class FavouritePage : ContentPage
    {
        FavouritePageViewModel viewModel;

        public FavouritePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FavouritePageViewModel();
        }

        void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var favourite = (sender as Switch).BindingContext as Favourite;
            if (favourite != null && e.Value == false)
            {
                viewModel.deleateFromFavourites.Add(favourite);
            }

            else if (favourite != null && e.Value == true)
            {
                viewModel.deleateFromFavourites.Remove(favourite);
            }
        }
    }



    //https://forums.xamarin.com/discussion/64197/switch-inside-listview-get-listview-item-on-toggle
    //public class ListSwitch : Switch
    //{
    //    public static readonly BindableProperty ConfigurationItemProperty = BindableProperty
    //            .Create(propertyName: "ConfigurationItem", returnType:
    //            typeof(ConfigurationItem), declaringType: typeof(ListSwitch), defaultValue: null);

    //    public ConfigurationItem ConfigurationItem
    //    {
    //        get
    //        {
    //            return (ConfigurationItem)GetValue(ConfigurationItemProperty);
    //        }
    //        set
    //        {
    //            SetValue(ConfigurationItemProperty, value);
    //        }
    //    }
    //}
}
