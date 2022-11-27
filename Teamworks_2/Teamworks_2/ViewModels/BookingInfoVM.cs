using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class BookingInfoVM : INotifyPropertyChanged
    {
        Services.Database DBInstance = new Services.Database();

        App globalref = (App)Application.Current;


        public BookingInfoVM()
        {
            UOfficeName = globalref.SelectedOffice.Name;
            UStartDate = DateTime.Now;
        }

        private string uOfficeName;
        public string UOfficeName
        {
            get
            {
                return uOfficeName;
            }
            set
            {
                uOfficeName = value;
                OnPropertyChanged("UOfficeName");
            }
        }

        private DateTime uStartDate;
        public DateTime UStartDate
        {
            get
            {
                return uStartDate;
            }
            set
            {
                uStartDate = value;
                OnPropertyChanged("UStartDate");
                CalculateBookingHourLenght();
            }
        }

        private TimeSpan uStartTime;
        public TimeSpan UStartTime
        {
            get
            {
                return uStartTime;
            }
            set
            {
                uStartTime = value;
                OnPropertyChanged("UStartTime");
            }
        }

        private DateTime uEndDate;
        public DateTime UEndDate
        {
            get
            {
                return uEndDate;
            }
            set
            {
                uEndDate = value;
                OnPropertyChanged("UEndDate");
            }
        }

        private TimeSpan uEndTime;
        public TimeSpan UEndTime
        {
            get
            {
                return uEndTime;
            }
            set
            {
                uEndTime = value;
                OnPropertyChanged("UEndTime");
            }
        }

        private int uNumPeople;
        public int UNumPeople
        {
            get
            {
                return uNumPeople;
            }
            set
            {
                uNumPeople = value;
                OnPropertyChanged("UNumPeople");
            }
        }

        private string uActivity;
        public string UActivity
        {
            get
            {
                return uActivity;
            }
            set
            {
                uActivity = value;
                OnPropertyChanged("UActivity");
            }
        }
        

        public bool IsBookingActive()
        {
            DateTime now = DateTime.Now;
            DateTime end = (uEndDate + uEndTime);
            if (now < end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double CalculateBookingHourLenght()
        {
            TimeSpan ts = (uEndDate + uEndTime) - (uStartDate + uStartTime);
            return Math.Round(ts.TotalHours);
        }

        public int SaveBooking()
        {
            int addstatus = 0;

            double numhours = CalculateBookingHourLenght();
            bool isActive = IsBookingActive();

            Models.Booking newbooking = new Models.Booking();
            newbooking.Start_datetime = UStartDate + UStartTime;
            newbooking.End_datetime = UEndDate + UEndTime;
            //newbooking.Start_time = UStartTime;
            //newbooking.End_time = UEndTime;
            newbooking.NumGuests = UNumPeople;
            newbooking.isActive = isActive;
            newbooking.Total_hours = numhours;
            newbooking.Activity = UActivity;
            newbooking.OID = globalref.SelectedOffice.OID;
            newbooking.UID = globalref.ActiveUser.UID;
            //newbooking.OfficePrice = UOfficePrice;
            //newbooking.ServiceFee = UServiceFee;
            //newbooking.FinalPrice = UFinalPrice;

            globalref.TempBooking = newbooking;

            //addstatus = DBInstance.AddBooking(newbooking);

            return addstatus;
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
