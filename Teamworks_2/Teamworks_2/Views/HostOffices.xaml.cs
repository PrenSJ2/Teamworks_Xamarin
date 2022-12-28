using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamworks_2.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HostOffices : ContentPage
    {
        ViewModels.HostOfficesVM hostofficesvm;
        //Make reference to the global class
        App globalref = (App)Application.Current;

        public HostOffices()
        {
            InitializeComponent();

            hostofficesvm = new ViewModels.HostOfficesVM();
            BindingContext = hostofficesvm;
        }

        private async void OfficesView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                globalref.SelectedOffice = hostofficesvm.SelectedOffice;
                //Models.Office thisoffice = e.CurrentSelection[0];
                //await Shell.Current.GoToAsync($"{nameof(BookNow)}?{nameof(ViewModels.BookNowVM.CurrentOffice)}={officesvm.SelectedOffice}");
                try
                {
                    await Shell.Current.GoToAsync("EditOffice");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "An error occurred while navigating to the EditOffice page: " + ex.Message, "OK");
                }
            }
        }

        void OfficesView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }

        private async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("AddOffice");
        }
        //private async void MainMovieView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)

        //{
        //    if (e.CurrentSelection != null)
        //    {
        //        globalref.SelectedOffice = SelectedOffice;
        //        await Navigation.PushModalAsync(new NavigationPage(new OfficeDetails()));
        //    }
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new HostOfficesVM();
        }
    }
}

