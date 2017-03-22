using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KidsApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_GoToEjerciciosDelDia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.EjerciciosDelDia.EjerciciosDelDia());
        }
        private async void Button_GoToProgresos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Progresos.Progresos());
        }
        private async void Button_GoToEjercicios(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Ejercicios.Ejercicios());
        }
        private async void Button_GoToTips(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Tips.Tips());
        }

        private async void Button_GoToHelp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Help.Help());
        }

        private async void Button_GoToExit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Exit());
        }
    }
}
