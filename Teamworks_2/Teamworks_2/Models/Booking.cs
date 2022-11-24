using System;
using SQLite;

namespace Teamworks_2.Models
{
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int BID { get; set; }
        public string Start_date { get; set; }
        public string Start_time { get; set; }
        public string End_date { get; set; }
        public string End_time { get; set; }
        public bool isActive { get; set; }
        public string Total_hours { get; set; }
        public int NumGuests { get; set; }
        public string Activity { get; set; }



        // Foregin key to Booked Office


        public double OfficePrice { get; set; }
        // list of booked selected addons

        public double AddonPrice { get; set; }

        // Foregin key to Booked User
        public int UID { get; set; }

        public double ServiceFee { get; set; } // set equal to (addon price + office price) * 0.15 
        public double FinalPrice { get; set; } // equal to office + addon + service 

    }
}

