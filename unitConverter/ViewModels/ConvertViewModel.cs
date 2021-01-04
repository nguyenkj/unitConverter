using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace unitConverter.ViewModels
{
    public class ConvertViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ConvertViewModel()
        {
            Title = "Convert";

            //ConvertCommand = new Command(execute: () => {  } ConvertGramsToKilograms(float.Parse(InputAmount))) ;
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

        //public void ConvertGramsToKilograms (float weight)
        //{
        //    ConvertAmount = weight / 1000;
        //}

        //public void ConvertPoundsToKilograms(float weight)
        //{
        //    ConvertAmount = weight / 1000;
        //}

        public ICommand ConvertCommand { get; }

        private string convertUnit;

        public string SelectedUnit
        {
            get { return convertUnit; }
            set { SetProperty(ref convertUnit, value, "SelectedUnit"); }
        }

        private float convertamount = 0;
        public float ConvertAmount
        {
            get { return convertamount; }
            set { SetProperty(ref convertamount, value, "ConvertAmount"); }
        }

        public string InputAmount { get; set; }
        public string OutputAmount { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        public class ConvertableUnit
        {
            public string Name { get; set; }
        }
    }
}
