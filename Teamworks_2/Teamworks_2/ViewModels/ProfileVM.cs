using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
	public class ProfileVM : INotifyPropertyChanged
    {
        Services.Database newDBInstance;

        App globalref = (App)Application.Current;

        public ProfileVM()
        {
            LoadUser();
        }

        //private Models.User thisuser;

        //public Models.User Thisuser
        //{
        //    get
        //    {
        //        return thisuser;
        //    }
        //    set
        //    {
        //        thisuser = value;
        //        OnPropertyChanged("Thisuser");
        //    }
        //}

        private int userid { get; set; }

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

        private string uEmail;
        public string UEmail
        {
            get
            {
                return uEmail;
            }
            set
            {
                uEmail = value;
                OnPropertyChanged("UEmail");
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

        private string uPassword;
        public string UPassword
        {
            get
            {
                return uPassword;
            }
            set
            {
                uPassword = value;
                OnPropertyChanged("UPassword");
            }
        }

        public void ValidateUserEmail()
        {
            // validate the username
            var trimmedEmail = UEmail.Trim();

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

        public void LoadUser()
        {
            // get the selected user by activeuser Id
            //int uid = globalref.ActiveUser.UID;

            //Models.User selectedUser = newDBInstance.GetUserByID(uid);
            Models.User selectedUser = globalref.ActiveUser;
            userid = selectedUser.UID;
            UFirstName = selectedUser.First_name;
            ULastName = selectedUser.Last_name;
            UEmail = selectedUser.Email;
            UPhoneNo = selectedUser.Phone_number;
            UPassword = selectedUser.Password;
            if (selectedUser.isHost)
            {
                UisHost = "True";
            }
            else
            {
                UisHost = "False";
            }
            ValidateUserEmail();

        }

        public void UpdateUser()
        {
            Models.User newuser = new Models.User();

            newuser.UID = userid;
            newuser.First_name = UFirstName;
            newuser.Last_name = ULastName;
            newuser.Email = UEmail;
            newuser.Phone_number = UPhoneNo;
            newuser.Password = UPassword;
            if (UisHost == "True")
            {
                newuser.isHost = true;
            }
            else
            {
                newuser.isHost = false;
            }

            newDBInstance = new Services.Database();
            if (ValidEmail == "Green")
            {
                newDBInstance.UpdateUser(newuser);
            }
            
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

