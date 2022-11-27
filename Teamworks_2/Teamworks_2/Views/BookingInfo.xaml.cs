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
    public partial class BookingInfo : ContentPage
    {
        ViewModels.BookingInfoVM bookinginfovm;

        public BookingInfo()
        {
            InitializeComponent();

            bookinginfovm = new ViewModels.BookingInfoVM();
            BindingContext = bookinginfovm;
        }

        private async void btnContinue_Clicked(System.Object sender, System.EventArgs e)
        {
            bookinginfovm.SaveBooking();
            await Shell.Current.GoToAsync("BookingPayment");
        }
    }
}

