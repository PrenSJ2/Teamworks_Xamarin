using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
	public class ProfileVM : INotifyPropertyChanged
    {
        Services.Database DBInstance;

        App globalref = (App)Application.Current;

        private string uFirstName;
        public string UFirstName
        {
            get
            {
                return uFirstName;
            }
            set
            {
                uFirstName = value;
                OnPropertyChanged("UFirstName");
            }
        }

        private string uLastName;
        public string ULastName
        {
            get
            {
                return uLastName;
            }
            set
            {
                uLastName = value;
                OnPropertyChanged("ULastName");
            }
        }

        private string pEmail;
        public string PEmail
        {
            get
            {
                return pEmail;
            }
            set
            {
                pEmail = value;
                OnPropertyChanged("PEmail");
                ValidateUserEmail();
            }
        }

        private string uPhoneNo;
        public string UPhoneNo
        {
            get
            {
                return uPhoneNo;
            }
            set
            {
                uPhoneNo = value;
                OnPropertyChanged("PEmail");
            }
        }

        private string validEmail;
        public string ValidEmail
        {
            get
            {
                return validEmail;
            }
            set
            {
                validEmail = value;
                OnPropertyChanged("ValidEmail");
            }
        }

        private string uisHost;
        public string UisHost
        {
            get
            {
                return uisHost;
            }
            set
            {
                uisHost = value;
                OnPropertyChanged("UisHost");
            }
        }

        public void ValidateUserEmail()
        {
            // validate the username
            var trimmedEmail = pEmail.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                ValidEmail = "Red";
            }
            try
            {
                ValidEmail = "Green";
            }
            catch
            {
                ValidEmail = "Red";
            }
        }

        public int SaveUser()
        {
            int addstatus = 0;
            Models.User newuser = new Models.User();
            newuser.First_name = UFirstName;
            newuser.Last_name = ULastName;
            newuser.Email = pEmail;
            newuser.Phone_number = UPhoneNo;
            if (UisHost == "True")
            {
                newuser.isHost = true;
            }
            else
            {
                newuser.isHost = false;
            }




            if (ValidEmail == "Green")
            {
                addstatus = DBInstance.AddUser(newuser);
            }

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

