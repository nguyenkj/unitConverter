using SQLite;
using System;
using unitConverter.Services;
using unitConverter.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using unitConverter.Models;
using System.Collections.Generic;

namespace unitConverter
{
    public partial class App : Application
    {
        static UselessThingDatabase database;

        public static UselessThingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UselessThingDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UselessThings.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            App.Database.FillUselessThingTable();
        } 

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
