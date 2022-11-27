using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
	public class BookingPaymentVM : INotifyPropertyChanged
    {
        Services.Database DBInstance = new Services.Database();

        App globalref = (App)Application.Current;

        public BookingPaymentVM()
		{
            BookingOffice = globalref.SelectedOffice;
            ThisBooking = globalref.TempBooking;
            TimePeriod = ThisBooking.Start_datetime.ToString() + " - " + ThisBooking.End_datetime.ToString();
            
            UOfficePrice = ThisBooking.Total_hours * globalref.SelectedOffice.Hourly;
            UServiceFee = UOfficePrice * 0.15;
            UFinalPrice = UOfficePrice + UServiceFee;
        }

        private string timeperiod;
        public string TimePeriod
        {
            get
            {
                return timeperiod;
            }
            set
            {
                timeperiod = value;
                OnPropertyChanged("TimePeriod");
            }
        }

        private Models.Office bookingoffice;
        public Models.Office BookingOffice
        {
            get
            {
                return bookingoffice;
            }
            set
            {
                bookingoffice = value;
                OnPropertyChanged("BookingOffice");
            }
        }

        private Models.Booking thisbooking;
        public Models.Booking ThisBooking
        {
            get
            {
                return thisbooking;
            }
            set
            {
                thisbooking = value;
                OnPropertyChanged("ThisBooking");
            }
        }



        private double uOfficePrice;
        public double UOfficePrice
        {
            get
            {
                //double numhours = CalculateBookingHourLenght();
                //uOfficePrice = numhours * globalref.SelectedOffice.Hourly;
                return uOfficePrice;
            }
            set
            {
                uOfficePrice = value;
                OnPropertyChanged("UOfficePrice");

            }
        }
        private double uServiceFee;
        public double UServiceFee
        {
            get
            {
                return uServiceFee;
            }
            set
            {
                uServiceFee = value;
                OnPropertyChanged("UServiceFee");

            }
        }
        private double uFinalPrice;
        public double UFinalPrice
        {
            get
            {
                return uFinalPrice;
            }
            set
            {
                uFinalPrice = value;
                OnPropertyChanged("UFinalPrice");

            }
        }

        public bool IsBookingActive()
        {
            DateTime now = DateTime.Now;
            DateTime end = globalref.TempBooking.End_datetime;
            if (now < end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SaveBooking()
        {
            int addstatus = 0;

            //double numhours = CalculateBookingHourLenght();
            bool isActive = IsBookingActive();

            Models.Booking newbooking = globalref.TempBooking;
            //newbooking.Start_datetime = UStartDate + UStartTime;
            //newbooking.End_datetime = UEndDate + UEndTime;
            ////newbooking.Start_time = UStartTime;
            ////newbooking.End_time = UEndTime;
            newbooking.isActive = isActive;
            //newbooking.Total_hours = numhours;
            //newbooking.Activity = UActivity;
            //newbooking.OID = globalref.SelectedOffice.OID;
            //newbooking.UID = globalref.ActiveUser.UID;
            newbooking.TimePeriod = TimePeriod;
            newbooking.OfficePrice = UOfficePrice;
            newbooking.ServiceFee = UServiceFee;
            newbooking.FinalPrice = UFinalPrice;

            // Save Guest Name to Booking
            newbooking.GName = globalref.ActiveUser.First_name + " " + globalref.ActiveUser.Last_name;

            // Save Office Details to Booking
            newbooking.HID = BookingOffice.UID;
            newbooking.OName = BookingOffice.Name;
            newbooking.OLocation = BookingOffice.Location;

            //globalref.TempBooking = newbooking;

            addstatus = DBInstance.AddBooking(newbooking);

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

