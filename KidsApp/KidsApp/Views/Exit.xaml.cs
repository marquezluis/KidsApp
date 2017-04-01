using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exit : ContentPage
    {
        public Exit()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ExitViewModel();
        }

    }
}
