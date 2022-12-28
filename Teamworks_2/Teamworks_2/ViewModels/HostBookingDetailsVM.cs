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
    public class HostBookingDetailsVM
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public HostBookingDetailsVM()
        {
            newDBInstance = new Services.Database();

            CurrentBooking = globalref.SelectedBooking;
            BookedGuest = newDBInstance.GetUserByID(globalref.SelectedBooking.UID);
            CurrentOffice = newDBInstance.GetOfficeByID(globalref.SelectedBooking.OID);
            AllOfficeAddons = newDBInstance.GetAllAddonsByOID(globalref.SelectedBooking.OID);

        }

        private ObservableCollection<Models.Addon> allofficeaddons;

        public ObservableCollection<Models.Addon> AllOfficeAddons
        {
            get
            {
                return allofficeaddons;
            }
            set
            {
                allofficeaddons = value;
                OnPropertyChanged("AllOfficeAddons");
            }
        }

        private Models.User bookedguest;
        public Models.User BookedGuest
        {
            get
            {
                return bookedguest;
            }
            set
            {
                bookedguest = value;
                OnPropertyChanged("BookedGuest");
            }
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

