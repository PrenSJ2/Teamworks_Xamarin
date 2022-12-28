using System;
using Teamworks_2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Teamworks_2;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class BookingDetailsVM
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public BookingDetailsVM()
        {
            newDBInstance = new Services.Database();

            CurrentBooking = globalref.SelectedBooking;
            //Models.User CurrentUser = newDBInstance.GetUserByID(globalref.SelectedBooking.UID);
            CurrentOffice = newDBInstance.GetOfficeByID(globalref.SelectedBooking.OID);
            
        }

        private Models.Office currentoffice;
        public Models.Office CurrentOffice
        {
            get
            {
                return currentoffice;
            }
            set
            {
                currentoffice = value;
                OnPropertyChanged("CurrentOffice");
            }
        }

        private Models.Booking currentbooking;
        public Models.Booking CurrentBooking
        {
            get
            {
                return currentbooking;
            }
            set
            {
                currentbooking = value;
                OnPropertyChanged("CurrentBooking");
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

