using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace unitConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertPage : ContentPage
    {
        public ConvertPage()
        {
            InitializeComponent();

            BindingContext = new ConvertViewModel();
        }
    }
}