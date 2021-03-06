﻿using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
            this.BindingContext = new HelpViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
