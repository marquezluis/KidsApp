using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KidsApp
{
    public partial class welcome : ContentPage
    {
        public welcome()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Usable when needs to disappear the navigation toolbar//
            this.BindingContext = new welcomeViewModel();
        }

    }
}