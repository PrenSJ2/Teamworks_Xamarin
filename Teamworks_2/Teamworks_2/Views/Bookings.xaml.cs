using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bookings : ContentPage
    {
        ViewModels.BookingsVM bookingsvm;

        App globalref = (App)Application.Current;

        public Bookings()
        {
            InitializeComponent();

            bookingsvm = new ViewModels.BookingsVM();
            BindingContext = bookingsvm;
        }

        protected override void OnAppearing()
        {
            bookingsvm = new ViewModels.BookingsVM();
            BindingContext = bookingsvm;
        }

        private async void btnAddPerson_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewPerson()));
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                globalref.SelectedBooking = e.SelectedItem as Models.Booking;
                //await Navigation.PushModalAsync(new NavigationPage(new PersonDetails()));

            }
        }

        protected override bool OnBackButtonPressed()
        {
            // Override and do nothing when back button is pressed
            return true;
        }

        private async void tlbSignOut_Clicked(object sender, EventArgs e)
        {
            bool confirmation = await DisplayAlert("Sign Out Confirmation", "Are you sure you want to Sign Out?", "OK", "Cancel");

            if (confirmation)
            {
                //await Navigation.PushModalAsync(new Home());
            }
        }
    }
}

