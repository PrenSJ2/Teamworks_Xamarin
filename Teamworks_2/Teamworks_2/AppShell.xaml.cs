﻿using System;
using System.Collections.Generic;
using Teamworks_2.ViewModels;
using Teamworks_2.Views;
using Xamarin.Forms;

namespace Teamworks_2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

