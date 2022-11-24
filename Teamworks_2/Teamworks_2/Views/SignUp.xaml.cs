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
    public partial class SignUp : ContentPage
    {
        ViewModels.SignUpVM signupViewModel;

        public SignUp()
        {
            InitializeComponent();

            signupViewModel = new ViewModels.SignUpVM();
            BindingContext = signupViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            // Override and do nothing when back button is pressed
            return true;
        }

        private async void btnConfirm_Clicked(object sender, EventArgs e)
        {
            int signinstatus = signupViewModel.SaveUser();

            if (signinstatus != 0)
            {
                await Navigation.PushModalAsync(new NavigationPage(new SignIn()));
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignIn()));
        }
    }
}