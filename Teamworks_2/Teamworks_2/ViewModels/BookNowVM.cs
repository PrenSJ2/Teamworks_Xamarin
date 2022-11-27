using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Teamworks_2;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class BookNowVM
    {
        Services.Database newDBInstance;
        App globalref = (App)Application.Current;

        public BookNowVM()
        {
            // Create an instance of the DB Class
            newDBInstance = new Services.Database();

            // Load from DB into attribute
            //CurrentOffice = newDBInstance.GetOfficeByID(globalref.SelectedOffice.OID);
            CurrentOffice = globalref.SelectedOffice;
           

        }

        private Models.Office currentoffice;

        public Models.Office CurrentOffice
        {
            get
            {
                return currentoffice;
            }
            set
            {
                currentoffice = value;
                OnPropertyChanged("CurrentOffice");
            }
        }


        //private void LoadOffice()
        //{
            
        //}

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