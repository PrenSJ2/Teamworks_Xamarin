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
            int newProfileDeets = profileViewModel.SaveUser();

        }
    }
}

