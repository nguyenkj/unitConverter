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
    public partial class LengthConvertPage : ContentPage
    {
        public LengthConvertPage()
        {
            InitializeComponent();

            BindingContext = new ConvertViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<UselessThing> DatabaseList = await App.Database.GetUselessThingsAsync();

            List<UselessThing> UselessThings = DatabaseList.OrderBy(x => x.Type).ThenBy(x => x.Name).ToList();

            FromUnitP.ItemsSource = UselessThings;
            ToUnitP.ItemsSource = UselessThings;
        }

        private void UnitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ThisViewModel = (ConvertViewModel)BindingContext;

            if (ThisViewModel.CheckAllFieldsCompleted() == true)
                ThisViewModel.ConvertLengthCommand.Execute(null);              
        }

        private void InputAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ThisViewModel = (ConvertViewModel)BindingContext;

            if (ThisViewModel.CheckAllFieldsCompleted() == true)
                ThisViewModel.ConvertLengthCommand.Execute(null);
        }
    }
}