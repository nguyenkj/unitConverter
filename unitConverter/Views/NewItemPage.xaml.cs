using System;
using System.Collections.Generic;
using System.ComponentModel;
using unitConverter.Models;
using unitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace unitConverter.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}