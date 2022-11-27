using System;
using SQLite;

namespace Teamworks_2.Models
{
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int BID { get; set; }
        public DateTime Start_datetime { get; set; }
        //public TimeSpan Start_time { get; set; }
        public DateTime End_datetime { get; set; }
        //public TimeSpan End_time { get; set; }
        public bool isActive { get; set; }
        public double Total_hours { get; set; }
        public int NumGuests { get; set; }
        public string Activity { get; set; }
        public string TimePeriod { get; set; }
        //Payment



        // Foregin key to Booked Office
        public int OID { get; set; }
        public int HID { get; set; }
        public string OName { get; set; }
        public string OLocation { get; set; }

        
        // list of booked selected addons

        //public double TotalAddonPrice { get; set; }

        // Foregin key to Guest User
        public int UID { get; set; }
        public string GName { get; set; }


        public double OfficePrice { get; set; } // Office Hourly * Total_hours
        public double ServiceFee { get; set; } // set equal to (addon price + office price) * 0.15 
        public double FinalPrice { get; set; } // equal to office + addon + service 

    }
}

