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
            NavigationPage.SetHasNavigationBar(this, false); //Usable when needs to disappear the navigation toolbar//

        }

        private async void Button_GoToLoading(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Loading());
        }

        private async void Button_GoToPreaccept(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Registration.Preaccept());
        }
    }

}
