using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class SignInVM : INotifyPropertyChanged
    {
        Services.Database DBInstance;

        App globalref = (App)Application.Current;

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

        public bool AuthenticateManager()
        {
            bool valid = false;

            DBInstance = new Services.Database();
            var founduser = DBInstance.ValidateUser(UEmail, UPassword);

            globalref.isGuestLoggedIn = true;
            globalref.isHostLoggedIn = false;

            if (founduser != null)
            {
                valid = true;
                globalref.ActiveUser = founduser;

                //if (founduser.isHost)
                //{
                //    globalref.isHostLoggedIn = true;
                //    globalref.isGuestLoggedIn = false;

                //}
                //else
                //{
                //    globalref.isGuestLoggedIn = true;
                //    globalref.isHostLoggedIn = false;

                //}
            }

            return valid;
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
