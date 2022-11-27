using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teamworks_2.Models
{
    public class Office
    {
        [PrimaryKey, AutoIncrement]
        public int OID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string NumGuests { get; set; }
        public string Sqft { get; set; }
        public string Description { get; set; }
        public double Hourly { get; set; }
        public string MinHours { get; set; }
        public string Amenities { get; set; }
        public string Features { get; set; }
        public string Image { get; set; }

        // link Office to Host
        public int UID { get; set; }
    }
}

