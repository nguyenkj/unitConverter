using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using unitConverter.Models;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using SQLite;

namespace unitConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeightConvertPage : ContentPage
    {
        public WeightConvertPage()
        {
            InitializeComponent();

            BindingContext = new ConvertViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<UselessThing> UselessThings = await App.Database.GetUselessThingsAsync();

            FromUnitP.ItemsSource = UselessThings;
            ToUnitP.ItemsSource = UselessThings;
        }
    }
}