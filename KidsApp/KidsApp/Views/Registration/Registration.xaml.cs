using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            Title = "Registro";
            NavigationPage.SetHasNavigationBar(this, false); //Usable when needs to disappear the navigation toolbar//
        }

        private async void Button_GoToWelcome(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new welcome(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}
