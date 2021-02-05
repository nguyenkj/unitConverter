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
using unitConverter.Models;
using SQLite;

namespace unitConverter.ViewModels
{
    public class ConvertViewModel : BaseViewModel, INotifyPropertyChanged
    {
        readonly UselessThingDatabase dbHelper = App.Database;

        public ConvertViewModel()
        {
            WeightPageTitle = "WEIGHT CONVERSIONS";
            LengthPageTitle = "LENGTH CONVERSIONS";

            ConvertWeightCommand = new Command(execute => ConvertWeight(InputAmount));

            ConvertLengthCommand = new Command(execute => ConvertLength(InputAmount));
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

        public async void ConvertWeight(float input)
        {
            UselessThing fromThing = await dbHelper.GetUselessThingByNameAsync(FromUnit.Name);
            UselessThing toThing = await dbHelper.GetUselessThingByNameAsync(ToUnit.Name);

            float fromWeight;
            float toWeight;

            if (FromUnit == null || ToUnit == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select units to convert.", "OK");
            }
            else
            {
                fromWeight = fromThing.Weight;
                toWeight = toThing.Weight;
                
                OutputAmount = (input * (fromWeight / toWeight));
            }
        }

        public async void ConvertLength(float input)
        {
            UselessThing fromThing = await dbHelper.GetUselessThingByNameAsync(FromUnit.Name);
            UselessThing toThing = await dbHelper.GetUselessThingByNameAsync(ToUnit.Name);

            float fromLength;
            float toLength;

            if (FromUnit == null || ToUnit == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select units to convert.", "OK");
            }
            else
            {
                fromLength = fromThing.Length;
                toLength = toThing.Length;

                OutputAmount = (input * (fromLength / toLength));
            }
        }

        public bool CheckAllFieldsCompleted()
        {
            if (FromUnit == null || ToUnit == null || InputAmount == 0)
                return false;

            return true;
        }

        public ICommand ConvertWeightCommand { get; }

        public ICommand ConvertLengthCommand { get; }

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

        public float inputamount = 0;
        public float outputamount;

        public float InputAmount
        {
            get { return inputamount; }
            set { SetProperty(ref inputamount, value, "InputAmount"); }
        }
        public float OutputAmount
        {
            get { return outputamount; }
            set { SetProperty(ref outputamount, value, "OutputAmount"); }
        }

        public UselessThing fromunit;
        public UselessThing FromUnit
        {
            get { return fromunit; }
            set { SetProperty(ref fromunit, value, "FromUnit"); }
        }

        public UselessThing tounit;
        public UselessThing ToUnit
        {
            get { return tounit; }
            set { SetProperty(ref tounit, value, "ToUnit"); }
        }

        public string WeightPageTitle { get; private set; }
        public string LengthPageTitle { get; private set; }

        public class ConvertableUnit
        {
            public string Name { get; set; }
        }
    }
}
