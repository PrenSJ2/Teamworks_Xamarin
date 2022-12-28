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
    public partial class Offices : ContentPage
    {
        ViewModels.OfficesVM officesvm;
        //Make reference to the global class
        App globalref = (App)Application.Current;

        public Offices()
        {
            InitializeComponent();

            officesvm = new ViewModels.OfficesVM();
            BindingContext = officesvm;
        }

        

        private async void OfficesView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                globalref.SelectedOffice = officesvm.SelectedOffice;
                //Models.Office thisoffice = e.CurrentSelection[0];
                //await Shell.Current.GoToAsync($"{nameof(BookNow)}?{nameof(ViewModels.BookNowVM.CurrentOffice)}={officesvm.SelectedOffice}");
                await Shell.Current.GoToAsync("BookNow");

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new OfficesVM();
        }

        //private async void MainMovieView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)

        //{
        //    if (e.CurrentSelection != null)
        //    {
        //        globalref.SelectedOffice = SelectedOffice;
        //        await Navigation.PushModalAsync(new NavigationPage(new OfficeDetails()));
        //    }
        //}
    }
}

