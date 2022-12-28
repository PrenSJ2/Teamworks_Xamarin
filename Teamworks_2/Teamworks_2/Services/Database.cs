using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Teamworks_2.Models;
using Teamworks_2.Views;

namespace Teamworks_2.Services
{
    public class Database
    {
        public string CurrentState; // to hold the current db state
        static SQLiteConnection DatabaseConnection; // to hold and establish the connection

        public Database()
        {
            try
            {
                // Make the connection
                DatabaseConnection = new SQLiteConnection(DBConnection.DatabasePath, DBConnection.Flags);

                // Create a Table
                DatabaseConnection.CreateTable<Models.Addon>();
                DatabaseConnection.CreateTable<Models.Booking>();
                DatabaseConnection.CreateTable<Models.Office>();
                DatabaseConnection.CreateTable<Models.User>();


                // set the status of the DB
                CurrentState = "Database and Table Created";
            }
            catch (SQLiteException excep)
            {
                CurrentState = excep.Message;
            }
        }

        // DB Utility Functions

        // USERS

        // Insert a new User
        public int AddUser(Models.User user)
        {
            int insertstatus = 0;
            try
            {
                // Insert into the table and return the status of the inset
                insertstatus = DatabaseConnection.Insert(user);
            }
            catch (Exception ex)
            {
                var messgae = ex.Message;
            }

            return insertstatus;
        }

        // Update a User
        public int UpdateUser(Models.User user)
        {
            int updatestatus = DatabaseConnection.Update(user);
            return updatestatus;
        }

        // Return a User based on The UserID
        public Models.User GetUserByID(int uid)
        {

            // Query to return a persons in the DB by ID
            var user = DatabaseConnection.Table<Models.User>()
                            .Where(usr => usr.UID == uid)
                            .FirstOrDefault();
            return user;
        }

        public bool ValidateUsername(string username)
        {
            bool valid = false;

            // Insert into the table and return the status of the inset
            var numfoundrecords = DatabaseConnection.Table<Models.User>()
                .Where(user => user.Email == username)
                .Count();

            // if no records found, then the entered username is valid
            if (numfoundrecords == 0)
            {
                valid = true;
            }

            return valid;
        }

        // Validate the attempted log in
        public Models.User ValidateUser(string uusername, string upassword)
        {
            // check if the manager exists
            var founduser = DatabaseConnection.Table<Models.User>()
                .Where(user => user.Email == uusername & user.Password == upassword)
                .FirstOrDefault();

            return founduser;
        }

        // OFFICES

        // Insert a new Office
        public int AddOffice(Models.Office office)
        {
            // Insert into the table and return the status of the inset
            var insertstatus = DatabaseConnection.Insert(office);
            return insertstatus;
        }

        // Delete a office
        public int DeleteOffice(Models.Office office)
        {
            // Query to return all persons in the DB
            var deletestatus = DatabaseConnection.Delete(office);
            return deletestatus;
        }

        // Update a office
        public int UpdateOffice(Models.Office office)
        {
            // Query to return all persons in the DB
            var updatestatus = DatabaseConnection.Update(office);
            return updatestatus;
        }

        // Return ALL Offices
        public ObservableCollection<Models.Office> GetAllOffices()
        {
            ObservableCollection<Models.Office> offices;

            // Query to return all persons in the DB
            var alloffices = DatabaseConnection.Table<Models.Office>().ToList();
            offices = new ObservableCollection<Models.Office>(alloffices);
            return offices;
        }

        // Return ALL Offices per Signed In User
        //public ObservableCollection<Office> GetAllHostOffices(int uid)
        //{
        //    ObservableCollection<Office> offices;

        //    // Query to return all persons in the DB
        //    var alloffices = DatabaseConnection.Table<Office>()
        //        .Where(offi => offi.OID == managerid)
        //        .ToList();
        //    persons = new ObservableCollection<Person>(allpersons);
        //    return persons;
        //}

        // Return a Office based on The Location or Name
        public ObservableCollection<Models.Office> GetOfficeByQuery(string oquery)
        {
            ObservableCollection<Models.Office> office;
            string getofficequery = "SELECT * FROM Office WHERE Location LIKE '%" + oquery + "%' OR Name LIKE '%" + oquery + "%'";

            // Query to return all persons in the DB
            var getoffice = DatabaseConnection.Query<Models.Office>(getofficequery);
            office = new ObservableCollection<Models.Office>(getoffice);
            return office;
        }

        // Return a Office based on The OfficeID
        public Models.Addon GetOfficeByID(int oid)
        {
            //Office office;

            // Query to return a persons in the DB by ID
            var alladdons = DatabaseConnection.Table<Models.Addon>()
                            .Where(offi => offi.OID == oid)
                            .ToList;
            addons = new ObservableCollection<Models.Addon>(alladdons);
            return addons;
        }

        // Addons

        // Insert a new addon
        public int AddAddon(Models.Addon addon)
        {
            var insertstatus = DatabaseConnection.Insert(addon);
            return insertstatus;
        }

        // Delete addon
        public int DeleteAddon(Models.Addon addon)
        {
            var deletestatus = DatabaseConnection.Delete(addon);
            return deletestatus;
        }

        // Update an addon
        public int UpdateAddon(Models.Addon addon)
        {
            var updatestatus = DatabaseConnection.Update(addon);
            return updatestatus;
        }

        // Return addons based on The office Id
        public Models.User GetAddonsByOID(int oid)
        {

            // Query to return a persons in the DB by ID
            var user = DatabaseConnection.Table<Models.Addon>()
                            .Where(usr => usr.OID == oid)
                            .FirstOrDefault();
            return user;
        }

        // Bookings

        // Insert a new Booking
        public int AddBooking(Models.Booking booking)
        {
            // Insert into the table and return the status of the inset
            var insertstatus = DatabaseConnection.Insert(booking);
            return insertstatus;
        }

        // Delete a booking
        public int DeleteBooking(Models.Booking booking)
        {
            // Query to return all persons in the DB
            var deletestatus = DatabaseConnection.Delete(booking);
            return deletestatus;
        }

        // Update a booking
        public int UpdateBooking(Models.Booking booking)
        {
            // Query to return all persons in the DB
            var updatestatus = DatabaseConnection.Update(booking);
            return updatestatus;
        }

        // Return ALL bookings
        public ObservableCollection<Models.Booking> GetAllBookings(int uid)
        {
            ObservableCollection<Models.Booking> bookings;

            // Query to return all persons in the DB
            var allbookings = DatabaseConnection.Table<Models.Booking>()
                .Where(book => book.UID == uid)
                .ToList();
            bookings = new ObservableCollection<Models.Booking>(allbookings);
            return bookings;
        }

        // Return ALL Host bookings
        public ObservableCollection<Models.Booking> GetAllHostBookings(int hid)
        {
            ObservableCollection<Models.Booking> bookings;

            // Query to return all persons in the DB
            var allbookings = DatabaseConnection.Table<Models.Booking>()
                .Where(book => book.HID == hid)
                .ToList();
            bookings = new ObservableCollection<Models.Booking>(allbookings);
            return bookings;
        }


        // Return a Booking based on The Location or Name
        public ObservableCollection<Models.Booking> GetBookingByQuery(string oquery)
        {
            ObservableCollection<Models.Booking> booking;
            string getbookingquery = "SELECT * FROM Booking WHERE Location LIKE '%" + oquery + "%' OR Name LIKE '%" + oquery + "%'";

            // Query to return all booking in the DB
            var getbooking = DatabaseConnection.Query<Models.Booking>(getbookingquery);
            booking = new ObservableCollection<Models.Booking>(getbooking);
            return booking;
        }


    }
}


