using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Teamworks_2;
using Xamarin.Forms;

namespace Teamworks_2.ViewModels
{
    public class AddOfficeVM : INotifyPropertyChanged
    {
        Services.Database DBInstance = new Services.Database();
        App globalref = (App)Application.Current;


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

        // double check for image
        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        // Addons

        private int addon_quantity;
        public int Addon_quantity
        {
            get
            {
                return addon_quantity;
            }
            set
            {
                addon_quantity = value;
                OnPropertyChanged("Addon_quantity");
            }
        }

        private string addon_name;
        public string Addon_name
        {
            get
            {
                return addon_name;
            }
            set
            {
                addon_name = value;
                OnPropertyChanged("Addon_name");
            }
        }

        private string addon_image;
        public string Addon_image
        {
            get
            {
                return addon_image;
            }
            set
            {
                addon_image = value;
                OnPropertyChanged("Addon_image");
            }
        }

        private double addon_price;
        public double Addon_price
        {
            get
            {
                return addon_price;
            }
            set
            {
                addon_price = value;
                OnPropertyChanged("Addon_price");
            }
        }

        private int addon2_quantity;
        public int Addon2_quantity
        {
            get
            {
                return addon2_quantity;
            }
            set
            {
                addon2_quantity = value;
                OnPropertyChanged("Addon2_quantity");
            }
        }

        private string addon2_name;
        public string Addon2_name
        {
            get
            {
                return addon2_name;
            }
            set
            {
                addon2_name = value;
                OnPropertyChanged("Addon2_name");
            }
        }

        private string addon2_image;
        public string Addon2_image
        {
            get
            {
                return addon2_image;
            }
            set
            {
                addon2_image = value;
                OnPropertyChanged("Addon2_image");
            }
        }

        private double addon2_price;
        public double Addon2_price
        {
            get
            {
                return addon2_price;
            }
            set
            {
                addon2_price = value;
                OnPropertyChanged("Addon2_price");
            }
        }

        private int addon3_quantity;
        public int Addon3_quantity
        {
            get
            {
                return addon3_quantity;
            }
            set
            {
                addon3_quantity = value;
                OnPropertyChanged("Addon3_quantity");
            }
        }

        private string addon3_name;
        public string Addon3_name
        {
            get
            {
                return addon3_name;
            }
            set
            {
                addon3_name = value;
                OnPropertyChanged("Addon3_name");
            }
        }

        private string addon3_image;
        public string Addon3_image
        {
            get
            {
                return addon3_image;
            }
            set
            {
                addon3_image = value;
                OnPropertyChanged("Addon3_image");
            }
        }

        private double addon3_price;
        public double Addon3_price
        {
            get
            {
                return addon3_price;
            }
            set
            {
                addon3_price = value;
                OnPropertyChanged("Addon3_price");
            }
        }

        private int addon4_quantity;
        public int Addon4_quantity
        {
            get
            {
                return addon4_quantity;
            }
            set
            {
                addon4_quantity = value;
                OnPropertyChanged("Addon4_quantity");
            }
        }

        private string addon4_name;
        public string Addon4_name
        {
            get
            {
                return addon4_name;
            }
            set
            {
                addon4_name = value;
                OnPropertyChanged("Addon4_name");
            }
        }

        private string addon4_image;
        public string Addon4_image
        {
            get
            {
                return addon4_image;
            }
            set
            {
                addon4_image = value;
                OnPropertyChanged("Addon4_image");
            }
        }

        private double addon4_price;
        public double Addon4_price
        {
            get
            {
                return addon4_price;
            }
            set
            {
                addon4_price = value;
                OnPropertyChanged("Addon4_price");
            }
        }

        private int addon5_quantity;
        public int Addon5_quantity
        {
            get
            {
                return addon5_quantity;
            }
            set
            {
                addon5_quantity = value;
                OnPropertyChanged("Addon5_quantity");
            }
        }

        private string addon5_name;
        public string Addon5_name
        {
            get
            {
                return addon5_name;
            }
            set
            {
                addon5_name = value;
                OnPropertyChanged("Addon5_name");
            }
        }

        private string addon5_image;
        public string Addon5_image
        {
            get
            {
                return addon5_image;
            }
            set
            {
                addon5_image = value;
                OnPropertyChanged("Addon5_image");
            }
        }

        private double addon5_price;
        public double Addon5_price
        {
            get
            {
                return addon5_price;
            }
            set
            {
                addon5_price = value;
                OnPropertyChanged("Addon5_price");
            }
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
            newoffice.Image = Image;
            newoffice.UID = globalref.ActiveUser.UID;

            //Addons
            Models.Addon newaddon = new Models.Addon();
            newaddon.ImgName = Addon_image;
            newaddon.Name = Addon_name;
            newaddon.Quantity = Addon_quantity;
            newaddon.Price = Addon_price;
            newaddon.OID = newoffice.OID;

            Models.Addon newaddon2 = new Models.Addon();
            newaddon2.ImgName = Addon2_image;
            newaddon2.Name = Addon2_name;
            newaddon2.Quantity = Addon2_quantity;
            newaddon2.Price = Addon2_price;
            newaddon2.OID = newoffice.OID;

            Models.Addon newaddon3 = new Models.Addon();
            newaddon3.ImgName = Addon3_image;
            newaddon3.Name = Addon3_name;
            newaddon3.Quantity = Addon3_quantity;
            newaddon3.Price = Addon3_price;
            newaddon3.OID = newoffice.OID;

            Models.Addon newaddon4 = new Models.Addon();
            newaddon4.ImgName = Addon4_image;
            newaddon4.Name = Addon4_name;
            newaddon4.Quantity = Addon4_quantity;
            newaddon4.Price = Addon4_price;
            newaddon4.OID = newoffice.OID;

            Models.Addon newaddon5 = new Models.Addon();
            newaddon5.ImgName = Addon5_image;
            newaddon5.Name = Addon5_name;
            newaddon5.Quantity = Addon5_quantity;
            newaddon5.Price = Addon5_price;
            newaddon5.OID = newoffice.OID;


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

