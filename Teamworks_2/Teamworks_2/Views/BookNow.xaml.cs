using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Teamworks_2.Views
{
    public partial class BookNow : ContentPage
    {
        ViewModels.BookNowVM booknowvm;
        //Make reference to the global class
        App globalref = (App)Application.Current;

        //public int SelectedIndex;

        //public Models.Office SelectedOffice { get; set; }
        ////public ViewModels.BookNowVM CurrentOffice { get; set; }
        ///
        public Models.Office office;


        public BookNow()
        {
            InitializeComponent();

            //CurrentOffice = globalref.SelectedOffice;
            //this.BindingContext = this;
            booknowvm = new ViewModels.BookNowVM();
            BindingContext = booknowvm;
            //SelectedOffice = globalref.SelectedOffice;
            //this.BindingContext = CurrentOffice;
        }

        private async void btnBookNow_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("BookingInfo");
        }

    }
}