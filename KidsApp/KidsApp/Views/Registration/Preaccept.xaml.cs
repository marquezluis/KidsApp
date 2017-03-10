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
    public partial class Preaccept : ContentPage
    {
        public Preaccept()
        {
            InitializeComponent();
        }

         private async void Button_GoToTermsAndConditions(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Registration.TermsAndConditions());
        }

        private async void Button_GoToRegistration(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Registration.Registration());
        }
    }
}
