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
        Services.Database newDBInstance;

        App globalref = (App)Application.Current;
        

        public BookingInfoVM()
        {
            UOfficeName = globalref.SelectedOffice.Name;
            uOID = globalref.SelectedOffice.OID;
            OfficeAddons = newDBInstance.GetAllAddonsByOID(uOID);
            UStartDate = DateTime.Now;
        }

        private int uOID;

        private ObservableCollection<Models.Addon> officeaddons;

        public ObservableCollection<Models.Addon> OfficeAddons
        {
            get
            {
                return officeaddons;
            }
            set
            {
                officeaddons = value;
                OnPropertyChanged("OfficeAddons");
            }
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

        //Addons Data to Booked Addons

        private string imgname;
        public string ImgName
        {
            get
            {
                return imgname;
            }
            set
            {
                imgname = value;
                OnPropertyChanged("ImgName");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private int steppervalue;
        public int StepperValue
        {
            get
            {
                return steppervalue;
            }
            set
            {
                steppervalue = value;
                OnPropertyChanged("StepperValue");
            }
        }

        private int selectedquantity;
        public int SelectedQuantity
        {
            get
            {
                return selectedquantity;
            }
            set
            {
                selectedquantity = steppervalue;
                OnPropertyChanged("SelectedQuantity");
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

            // Addons
            

            foreach (Models.Addon OfficeAddon in OfficeAddons)
                // foreach (StackLayout Data in CollectView:AddonSelection)
            {
                // if steppervalue >=1 then ...
                newbooking.BookedAddons.Add(new Models.Addon
                {
                    ImgName = OfficeAddon.ImgName,
                    Name = OfficeAddon.Name,
                    Price = OfficeAddon.Price,
                    Quantity = StepperValue //Stuck
                });
            }
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
