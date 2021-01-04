using System.ComponentModel;
using unitConverter.ViewModels;
using Xamarin.Forms;

namespace unitConverter.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}