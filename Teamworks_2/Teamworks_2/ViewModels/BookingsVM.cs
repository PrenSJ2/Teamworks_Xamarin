using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Teamworks_2;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class BookingsVM
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public BookingsVM()
        {
            // Create an instance of the DB Class
            newDBInstance = new Services.Database();

            // Load from DB into attribute
            Allbookings = newDBInstance.GetAllBookings(globalref.ActiveUser.UID);
        }

        private ObservableCollection<Models.Booking> allbookings;

        public ObservableCollection<Models.Booking> Allbookings
        {
            get
            {
                return allbookings;
            }
            set
            {
                allbookings = value;
                OnPropertyChanged("Allbookings");
            }
        }

        private string searchterm;

        public string SearchTerm
        {
            get
            {
                return searchterm;
            }
            set
            {
                searchterm = value;
                OnPropertyChanged("SearchTerm");
                OnSearch();
            }
        }

        private void OnSearch()
        {
            //var returnedbookings = newDBInstance.GetBookingByName(SearchTerm);
            //Allbookings = returnedbookings;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}

