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


        protected override bool OnBackButtonPressed()
        {
            // Override and do nothing when back button is pressed
            return true;
        }

        private async void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                globalref.SelectedBooking = e.SelectedItem as Models.Booking;
                await Shell.Current.GoToAsync("BookingDetails");
            }
        }
    }
}

