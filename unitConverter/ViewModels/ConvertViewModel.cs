using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using Xamarin.Essentials;

namespace unitConverter.ViewModels
{
    public class ConvertViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ConvertViewModel()
        {
            Title = "Convert";

            ConvertCommand = new Command(execute => ConvertUnits(InputAmount));
        }

        //public void convert()
        //{
        //    switch (FromUnit)
        //    {
        //        case "kg":
        //            _breedEnum = DogBreed.BorderCollie;
        //            break;
        //        case "Labrador Retriever":
        //            _breedEnum = DogBreed.LabradorRetriever;
        //            break;
        //        case "Pit Bull":
        //            _breedEnum = DogBreed.PitBull;
        //            break;
        //            //...
        //    }

        //    DoSomething(_breedEnum);
        //}

        public async void ConvertUnits(double input)
        {
            if (FromUnit == "Kilograms" && ToUnit == "Pounds")
                OutputAmount = UnitConverters.KilogramsToPounds(input);
            else if (FromUnit == "Pounds" && ToUnit == "Kilograms")
                OutputAmount = UnitConverters.PoundsToKilograms(input);
            else if (FromUnit == "Kilograms" && ToUnit == "Ounces")
                OutputAmount = input * 35.274;
            else if (FromUnit == "Ounces" && ToUnit == "Kilograms")
                OutputAmount = input * 0.0283495;
            else if (FromUnit == "Pounds" && ToUnit == "Ounces")
                OutputAmount = input * 16;
            else if (FromUnit == "Ounces" && ToUnit == "Pounds")
                OutputAmount = input * 0.0625;
            else if (FromUnit == "Kilograms" && ToUnit == "Grams")
                OutputAmount = input * 1000;
            else if (FromUnit == "Grams" && ToUnit == "Kilograms")
                OutputAmount = input * 0.001;
            else if (FromUnit == "Pounds" && ToUnit == "Grams")
                OutputAmount = input * 453.592;
            else if (FromUnit == "Grams" && ToUnit == "Pounds")
                OutputAmount = input * 0.00220462;
            else if (FromUnit == "Ounces" && ToUnit == "Grams")
                OutputAmount = input * 28.3495;
            else if (FromUnit == "Grams" && ToUnit == "Ounces")
                OutputAmount = input * 0.035274;
            else if (FromUnit == "Kilograms" && ToUnit == "1995 Honda Civic Hatch")
                OutputAmount = input / 1143;
            else if (FromUnit == "1995 Honda Civic Hatchback" && ToUnit == "Kilograms")
                OutputAmount = input * 1143;
            else if (FromUnit == ToUnit)
                OutputAmount = input;
            //Add below alerts for error cases. 
            else if (FromUnit == "" || ToUnit == "")
                await Application.Current.MainPage.DisplayAlert("Error", "Please select units to convert.", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "Cannot convert. Please contact administrator.", "OK");
        }

        public ICommand ConvertCommand { get; }

        private string convertUnit;

        public string SelectedUnit
        {
            get { return convertUnit; }
            set { SetProperty(ref convertUnit, value, "SelectedUnit"); }
        }

        private double convertamount = 0;
        public double ConvertAmount
        {
            get { return convertamount; }
            set { SetProperty(ref convertamount, value, "ConvertAmount"); }
        }

        public double inputamount;
        public double outputamount;

        public double InputAmount
        {
            get { return inputamount; }
            set { SetProperty(ref inputamount, value, "InputAmount"); }
        }
        public double OutputAmount
        {
            get { return outputamount; }
            set { SetProperty(ref outputamount, value, "OutputAmount"); }
        }

        public string fromunit;
        public string FromUnit
        {
            get { return fromunit; }
            set { SetProperty(ref fromunit, value, "FromUnit"); }
        }

        public string tounit;
        public string ToUnit
        {
            get { return tounit; }
            set { SetProperty(ref tounit, value, "ToUnit"); }
        }

        public class ConvertableUnit
        {
            public string Name { get; set; }
        }
    }
}
