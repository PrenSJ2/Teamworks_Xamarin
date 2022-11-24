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

        public Models.Office SelectedOffice { get; set; }

        void OfficesView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
        }

        void OfficesView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
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

