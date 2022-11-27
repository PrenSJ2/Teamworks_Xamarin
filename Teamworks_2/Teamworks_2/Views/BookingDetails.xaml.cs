using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingDetails : ContentPage
    {
        ViewModels.BookingDetailsVM bookingdetailsvm;
        public BookingDetails()
        {
            InitializeComponent();

            bookingdetailsvm = new ViewModels.BookingDetailsVM();
            BindingContext = bookingdetailsvm;
        }
    }
}

