﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Personas
{
    public partial class App : Application
    {
        static Controllers.DB db;
        public static Controllers.DB DB
        {
            get
            {
                if (db == null)
                {
                    var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var DBName = Models.Configuraciones.DBname;
                    var PathFull = Path.Combine(PathApp, DBName);

                    db = new Controllers.DB(PathFull);
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()){BarBackgroundColor= Color.FromHex("#fac055") };
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
