using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        // Insert a new User
        public int

            AddUser(Models.User user)
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
        //public ObservableCollection<Office> GetAllOffices(int userid)
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
        public Models.Office GetOfficeByID(int oid)
        {
            //Office office;

            // Query to return a persons in the DB by ID
            var office = DatabaseConnection.Table<Models.Office>()
                            .Where(offi => offi.OID == oid)
                            .FirstOrDefault();
            return office;
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



        //// Return a Office based on The Location or Name
        //public ObservableCollection<Booking> GetBookingByQuery(string oquery)
        //{
        //    ObservableCollection<Booking> booking;
        //    string getbookingquery = "SELECT * FROM Booking WHERE Location LIKE '%" + oquery + "%' OR Name LIKE '%" + oquery + "%'";

        //    // Query to return all booking in the DB
        //    var getbooking = DatabaseConnection.Query<Booking>(getbookingquery);
        //    booking = new ObservableCollection<Booking>(getbooking);
        //    return booking;
        //}
    }
}


