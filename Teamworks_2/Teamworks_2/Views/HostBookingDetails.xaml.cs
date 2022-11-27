using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HostBookingDetails : ContentPage
    {
        ViewModels.HostBookingDetailsVM hostbookingdetailsvm;
        public HostBookingDetails()
        {
            InitializeComponent();

            hostbookingdetailsvm = new ViewModels.HostBookingDetailsVM();
            BindingContext = hostbookingdetailsvm;
        }
    }
}

