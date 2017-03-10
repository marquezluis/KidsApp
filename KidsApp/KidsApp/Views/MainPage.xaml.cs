using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KidsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_GoToEjerciciosDelDia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.EjerciciosDelDia());
        }
        private async void Button_GoToProgresos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Progresos());
        }
        private async void Button_GoToEjercicios(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Ejercicios());
        }
        private async void Button_GoToTips(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Tips());
        }
    }
}
