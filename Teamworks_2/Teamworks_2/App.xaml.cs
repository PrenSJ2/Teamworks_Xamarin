using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Teamworks_2.Services;
using Teamworks_2.Views;

namespace Teamworks_2
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


        public Models.User ActiveUser;
        public Models.Office SelectedOffice;
        public Models.Booking SelectedBooking;
        public Models.Booking TempBooking;
        public Models.Addon SelectedAddon;

        public bool isHostLoggedIn { get; set; }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

