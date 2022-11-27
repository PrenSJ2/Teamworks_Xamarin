using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOffice : ContentPage
    {
        ViewModels.AddOfficeVM addofficeviewmodel;
        public AddOffice()
        {
            InitializeComponent();
            // like sign up

            addofficeviewmodel = new ViewModels.AddOfficeVM();
            BindingContext = addofficeviewmodel;
        }

        async void btnAddOffice_Clicked(System.Object sender, System.EventArgs e)
        {
            int addofficestatus = addofficeviewmodel.SaveOffice();
            if (addofficestatus !=0)
            {
                await DisplayAlert("Office Added", "Successfully", "OK");
                await Shell.Current.GoToAsync("//HostHome");
            }
        }

        async void btnCancel_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//HostHome");
        }
    }
}

