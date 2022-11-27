using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPayment : ContentPage
    {
        ViewModels.BookingPaymentVM bookingpayvm;

        public BookingPayment()
        {
            InitializeComponent();

            bookingpayvm = new ViewModels.BookingPaymentVM();
            BindingContext = bookingpayvm;
        }

        private async void Pay_Clicked(System.Object sender, System.EventArgs e)
        {
            int bookingsavestatus = bookingpayvm.SaveBooking();
            if (bookingsavestatus != 0)
            {
                await Shell.Current.GoToAsync("//Home");

            }
        }
    }
}

