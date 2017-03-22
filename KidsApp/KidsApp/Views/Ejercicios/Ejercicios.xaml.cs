using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Ejercicios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ejercicios : ContentPage
    {
        public Ejercicios()
        {
            InitializeComponent();
        }

        private async void Button_GoToNewbie(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Ejercicios.Newbie.Newbie());
        }

        private async void Button_GoToIntermediate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Ejercicios.Intermediate.Intermediate());
        }

        private async void Button_GoToAdvance(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Ejercicios.Advance.Advance());
        }
    }
}
