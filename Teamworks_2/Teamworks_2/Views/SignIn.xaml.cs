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
    public partial class SignIn : ContentPage
    {
        ViewModels.SignInVM signinViewModel;

        App globalref = (App)Application.Current;

        public SignIn()
        {
            InitializeComponent();

            signinViewModel = new ViewModels.SignInVM();
            BindingContext = signinViewModel;
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            // Call the LogIn Function
            var validstatus = signinViewModel.AuthenticateManager();


            if (validstatus)
            {
                if (globalref.isHostLoggedIn)
                {
                    await Shell.Current.GoToAsync("//HostHome");
                }
                else
                {
                    await Shell.Current.GoToAsync("//Home");
                }
                //await DisplayAlert("Authentication Successful", "Login Details Correct", "OK");
                
            }
            else
            {
                await DisplayAlert("Authentication Failed", "Invalid Username or Password", "OK");
                await Shell.Current.GoToAsync("//Login");
            }

        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            // Go to SignUp Page
            await Navigation.PushModalAsync(new NavigationPage(new SignUp()));
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            // Go to Home Page
            await Navigation.PushModalAsync(new NavigationPage(new SignIn()));
        }

        protected override bool OnBackButtonPressed()
        {
            // Override and do nothing when back button is pressed
            return true;
        }
    }
}