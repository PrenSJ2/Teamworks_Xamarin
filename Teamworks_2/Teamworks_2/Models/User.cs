using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace Teamworks_2.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UID { get; set; }
        public DateTime DateofBirth { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone_number { get; set; }
        public bool isHost { get; set; }
    }
}

