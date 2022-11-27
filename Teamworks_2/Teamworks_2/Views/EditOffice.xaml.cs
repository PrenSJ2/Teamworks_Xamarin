using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamworks_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EditOffice : ContentPage
    {
        ViewModels.EditOfficeVM editofficeviewmodel;

        //reference to global class
        App globalref = (App)Application.Current;

        public EditOffice()
        {
            InitializeComponent();

            editofficeviewmodel = new ViewModels.EditOfficeVM();
            BindingContext = editofficeviewmodel;
        }

        void btnSave_Clicked(System.Object sender, System.EventArgs e)
        {
            int editofficestatus = editofficeviewmodel.SaveOffice();
        }

        void btnCancel_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

