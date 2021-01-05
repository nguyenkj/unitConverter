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
            //
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

        public void ConvertUnits(double input)
        {
            OutputAmount = UnitConverters.KilogramsToPounds(input);
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
