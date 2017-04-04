using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsApp.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using KidsApp.Views;
using KidsApp.Extensions;
using KidsApp.ViewModels;
using KidsApp.Models.Extensions;
using KidsApp;
using KidsApp.Views.EjerciciosDelDia;
using KidsApp.Views.Progresos;
using KidsApp.Views.Ejercicios;
using KidsApp.Views.Tips;
using KidsApp.Views.Help;

namespace KidsApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            Info = new UserModel();
            GoToEjerciciosDelDia = new Command(async () => await OnReadyGoToEjerciciosDelDia());
            GoToProgresos = new Command(async () => await OnReadyGoToProgresos());
            GoToEjercicios = new Command(async () => await OnReadyGoToEjercicios());
            GoToTips = new Command(async () => await OnReadyGoToTips());
            GoToHelp = new Command(async () => await OnReadyGoToHelp());
            GoToExit = new Command(async () => await OnReadyGoToExit());
            OnLoad();

        }

        public UserModel Info { get; private set; }
        public Command GoToEjerciciosDelDia { get; set; }
        public Command GoToProgresos { get; set; }
        public Command GoToEjercicios { get; set; }
        public Command GoToTips { get; set; }
        public Command GoToHelp { get; set; }
        public Command GoToExit { get; set; }



        private async void OnLoad()
        {
                var a = DependencyService.Get<IFile>().Exist("Info");
                var jsonUser = DependencyService.Get<IFile>().LoadText("Info");
                Info = JsonConvert.DeserializeObject<UserModel>(jsonUser);
        }


        private async Task OnReadyGoToEjerciciosDelDia()
        {
            await App.Navigation.PushAsync(new EjerciciosDelDia());
        }
        private async Task OnReadyGoToProgresos()
        {
            await App.Navigation.PushAsync(new Progresos());
        }
        private async Task OnReadyGoToEjercicios()
        {
            await App.Navigation.PushAsync(new Ejercicios());
        }
        private async Task OnReadyGoToTips()
        {
            await App.Navigation.PushAsync(new Tips());
        }
        private async Task OnReadyGoToHelp()
        {
            await App.Navigation.PushAsync(new Help());
        }
        private async Task OnReadyGoToExit()
        {
            await App.Navigation.PushAsync(new Exit());
        }
    }
}