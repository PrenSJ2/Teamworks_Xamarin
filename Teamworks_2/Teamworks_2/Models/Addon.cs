using System;
using SQLite;

namespace Teamworks_2.Models
{
    public class Addon
    {
        [PrimaryKey, AutoIncrement]
        public int AID { get; set; }
        [Unique]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int StepperValue { get; set; }
        public double Price { get; set; }
        public string ImgName { get; set; }

        // link to Office by ID
        public int OID { get; set; }
    }
}