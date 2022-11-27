using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HostBookings : ContentPage
    {
        ViewModels.HostBookingsVM hostbookingsvm;

        App globalref = (App)Application.Current;

        public HostBookings()
        {
            InitializeComponent();

            hostbookingsvm = new ViewModels.HostBookingsVM();
            BindingContext = hostbookingsvm;
        }

        protected override void OnAppearing()
        {
            hostbookingsvm = new ViewModels.HostBookingsVM();
            BindingContext = hostbookingsvm;
        }


        protected override bool OnBackButtonPressed()
        {
            // Override and do nothing when back button is pressed
            return true;
        }

        async void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                globalref.SelectedBooking = e.SelectedItem as Models.Booking;
                await Shell.Current.GoToAsync("HostBookingDetails");
            }
        }
    }
}

