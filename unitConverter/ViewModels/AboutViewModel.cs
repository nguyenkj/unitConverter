using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace unitConverter.ViewModels
{
    public class AboutViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public AboutViewModel()
        {
            Title = "HOME";

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            OpenWebCommand2 = new Command(async () => await Browser.OpenAsync("https://hottouch.ca"));

            CounterCommand = new Command(execute => AddCount(globalcount));
        }

        public void AddCount (int count)
        {
            GlobalCount++;
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenWebCommand2 { get; }
        public ICommand CounterCommand { get; }
        
        private int globalcount = 0;
        public int GlobalCount
        {
            get { return globalcount; }
            set { SetProperty(ref globalcount, value, "GlobalCount"); }
        }
    }
}