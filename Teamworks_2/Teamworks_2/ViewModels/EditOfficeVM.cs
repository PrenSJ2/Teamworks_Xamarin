using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Teamworks_2.Models;
using Xamarin.Forms;


namespace Teamworks_2.ViewModels
{
    public class EditOfficeVM : INotifyPropertyChanged
    {
        Services.Database DBInstance = new Services.Database();

        App globalref = (App)Application.Current;

        public EditOfficeVM()
        {
            LoadOffice();
            //SelectImageCommand = new Command(SelectImage);

        }

        private string image;
        public string Image;

        public ICommand SelectImageCommand { get; set; }


        async void SelectImage()
        {
            var imageService = DependencyService.Get<IImageService>();
            var image = await imageService.PickImageAsync();

            // Set the image property in the view model to the selected image
            Image = image;
        }

        private string office_name;
        public string Office_name
        {
            get
            {
                return office_name;
            }
            set
            {
                office_name = value;
                OnPropertyChanged("Office_name");
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private string num_guests;
        public string Num_guests
        {
            get
            {
                return num_guests;
            }
            set
            {
                num_guests = value;
                OnPropertyChanged("Num_guests");
            }
        }

        private string sqft;
        public string Sqft
        {
            get
            {
                return sqft;
            }
            set
            {
                sqft = value;
                OnPropertyChanged("Sqft");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private double pricePerhour;
        public double PricePerhour
        {
            get
            {
                return pricePerhour;
            }
            set
            {
                pricePerhour = value;
                OnPropertyChanged("PricePerhour");
            }
        }

        private string minHours;
        public string MinHours
        {
            get
            {
                return minHours;
            }
            set
            {
                minHours = value;
                OnPropertyChanged("MinHours");
            }
        }


        private string amenities;
        public string Amenities
        {
            get
            {
                return amenities;
            }
            set
            {
                amenities = value;
                OnPropertyChanged("Amenities");
            }
        }

        private string features;
        public string Features
        {
            get
            {
                return features;
            }
            set
            {
                features = value;
                OnPropertyChanged("Features");
            }
        }


        public void LoadOffice()
        {
            Models.Office selectedOffice = globalref.SelectedOffice;
            Office_name = selectedOffice.Name;
            Location = selectedOffice.Location;
            Num_guests = selectedOffice.NumGuests;
            Sqft = selectedOffice.Sqft;
            Description = selectedOffice.Description;
            pricePerhour = selectedOffice.Hourly;
            MinHours = selectedOffice.MinHours;
            Amenities = selectedOffice.Amenities;
            Features = selectedOffice.Features;
        }
        public int SaveOffice()
        {
            int addstatus = 0;
            Models.Office newoffice = new Models.Office();
            newoffice.Name = Office_name;
            newoffice.Location = Location;
            newoffice.NumGuests = Num_guests;
            newoffice.Sqft = Sqft;
            newoffice.Description = Description;
            newoffice.Hourly = PricePerhour;
            newoffice.MinHours = MinHours;
            newoffice.Amenities = Amenities;
            newoffice.Features = Features;
            //newoffice.Image = Image;

            addstatus = DBInstance.AddOffice(newoffice);

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

