using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Teamworks_2.ViewModels
{
    public class SignUpVM : INotifyPropertyChanged
    {
        Services.Database DBInstance = new Services.Database();

        private string uFirst_name;
        public string UFirst_name
        {
            get
            {
                return uFirst_name;
            }
            set
            {
                uFirst_name = value;
                OnPropertyChanged("UFirst_name");
            }
        }

        private string uLast_name;
        public string ULast_name
        {
            get
            {
                return uLast_name;
            }
            set
            {
                uLast_name = value;
                OnPropertyChanged("ULast_name");
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
                ValidateUserEmail();
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

        public int SaveUser()
        {
            int addstatus = 0;
            Models.User newuser = new Models.User();
            newuser.First_name = UFirst_name;
            newuser.Last_name = ULast_name;
            newuser.Email = UEmail;
            newuser.Password = UPassword;
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
