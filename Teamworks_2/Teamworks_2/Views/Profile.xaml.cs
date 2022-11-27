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
    public partial class Profile : ContentPage
	{
        ViewModels.ProfileVM profileViewModel;

        public Profile ()
		{
			InitializeComponent();
			profileViewModel = new ViewModels.ProfileVM();
			BindingContext = profileViewModel;
		}

        void btnSave_Clicked(System.Object sender, System.EventArgs e)
        {
            // save user deets
            profileViewModel.UpdateUser();

        }

        private async void btnLogout_Clicked(System.Object sender, System.EventArgs e)
        {
            bool confirmation = await DisplayAlert("Sign Out Confirmation", "Are you sure you want to Sign Out?", "OK", "Cancel");

            if (confirmation)
            {
                await Shell.Current.GoToAsync("//Login");
            }
        }

        private async void btnHost_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//HostHome");
        }

        private async void btnGuest_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }
    }
}

