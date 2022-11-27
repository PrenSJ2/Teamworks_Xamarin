using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class HostOfficesVM : INotifyPropertyChanged
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public HostOfficesVM()
        {
            // Create an instance of the DB Class
            newDBInstance = new Services.Database();

            //Creating a Dummy Office

            //Models.Office dummyoffice = new Models.Office();
            //dummyoffice.Name = "Modern Conference Room";
            //dummyoffice.Location = "Central San Mateo, CA";
            //dummyoffice.NumGuests = "15 people";
            //dummyoffice.Sqft = "700 sqft";
            //dummyoffice.Hourly = "$95";
            //dummyoffice.MinHours = "4";
            //dummyoffice.Amenities = "Wifi, TV, Tables";
            //dummyoffice.Features = "Restrooms, Breakout Space, Parking";
            //dummyoffice.Image = "Modern_Large.jpeg";

            //newDBInstance.AddOffice(dummyoffice);

            // Load from DB into attribute
            AllOffices = newDBInstance.GetAllOffices();

        }
        public Models.Office SelectedOffice { get; set; }

        private ObservableCollection<Models.Office> alloffices;

        public ObservableCollection<Models.Office> AllOffices
        {
            get
            {
                return alloffices;
            }
            set
            {
                alloffices = value;
                OnPropertyChanged("AllOffices");
            }
        }

        private string searhterm;

        public string SearchTerm
        {
            get
            {
                return searhterm;
            }
            set
            {
                searhterm = value;
                OnPropertyChanged("SearchTerm");
                OnSearch();
            }
        }

        private void OnSearch()
        {
            var returnedoffices = newDBInstance.GetOfficeByQuery(SearchTerm);
            AllOffices = returnedoffices;
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

