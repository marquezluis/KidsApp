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


namespace KidsApp.ViewModels
{
    public class ProgresosViewModel : ViewModelBase
    {
        public ProgresosViewModel()
        {
            Info = new UserModel();
            GoToMainPage = new Command(async () => await OnReadyGoToMainPage());
            OnLoad();
        }
        public UserModel Info { get; private set; }
        public Command GoToMainPage { get; set; }


        private async void OnLoad()
        {
            var a = DependencyService.Get<IFile>().Exist("Info");
            var jsonUser = DependencyService.Get<IFile>().LoadText("Info");
            Info = JsonConvert.DeserializeObject<UserModel>(jsonUser);

            if (Info.Points <= 20)
            {
                Level = "Principiante";
            }
            if (Info.Points > 20 && Info.Points <= 40)
            {
                Level = "Intermedio";
            }
            if (Info.Points > 40)
            {
                Level = "Avanzado";
            }



            Info.Percentage = Percentage; //Ata el % al XAML

            if (Level == "Principiante") //Muestra el porcentaje
            {
                Remaining = 20 - Info.Points;
            }
            if (Level == "Intermedio")
            {
                Remaining = 40 - Info.Points;
            }
            if (Level == "Avanzado")
            {
                Remaining = 0;
            }
        }

        private string _Level;
        public string Level
        {
            get { return _Level; }
            set { _Level = value; OnPropertyChanged(); }
        }
        private int _Remaining;
        public int Remaining
        {
            get { return _Remaining; }
            set { _Remaining = value; OnPropertyChanged(); }
        }

        private decimal _Percentage;
        public decimal Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; OnPropertyChanged(); }
        }

        private async Task OnReadyGoToMainPage()
        {
            await App.Navigation.PushAsync(new MainPage());
        }
    }

}
