using System;
using System.Collections.Generic;
using Teamworks_2.ViewModels;
using Teamworks_2.Views;
using Xamarin.Forms;

namespace Teamworks_2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookNow), typeof(BookNow));
            Routing.RegisterRoute(nameof(BookingInfo), typeof(BookingInfo));
            Routing.RegisterRoute(nameof(BookingPayment), typeof(BookingPayment));
            Routing.RegisterRoute(nameof(AddOffice), typeof(AddOffice));
            Routing.RegisterRoute(nameof(EditOffice), typeof(EditOffice));
            Routing.RegisterRoute(nameof(BookingDetails), typeof(BookingDetails));
            Routing.RegisterRoute(nameof(HostBookingDetails), typeof(HostBookingDetails));



            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

