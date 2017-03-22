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
        }

        private async void Button_GoTowelcome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new welcome());
        }
    }
}
