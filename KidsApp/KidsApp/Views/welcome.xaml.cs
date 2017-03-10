using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KidsApp
{
    public partial class welcome: ContentPage
    {
        public welcome()
        {
            InitializeComponent();

        }

        private async void Button_GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_GoToPreaccept(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Registration.Preaccept());
        }
    }

}
