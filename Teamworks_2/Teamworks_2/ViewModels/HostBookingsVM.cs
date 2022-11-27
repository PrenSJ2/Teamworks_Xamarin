using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Teamworks_2;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class HostBookingsVM
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public HostBookingsVM()
        {
            // Create an instance of the DB Class
            newDBInstance = new Services.Database();

            // Load from DB into attribute
            AllBookings = newDBInstance.GetAllHostBookings(globalref.ActiveUser.UID);

        }

        private ObservableCollection<Models.Booking> allbookings;

        public ObservableCollection<Models.Booking> AllBookings
        {
            get
            {
                return allbookings;
            }
            set
            {
                allbookings = value;
                OnPropertyChanged("AllBookings");
            }
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

