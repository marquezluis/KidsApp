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

namespace KidsApp.ViewModels
{
    public class welcomeViewModel : ViewModelBase
    {
        public welcomeViewModel()
        {
            Info = new UserModel();
            GotoMainPage = new Command(async () => await OnReady());
            GotoTermsAndConditions = new Command(async () => await OnReadyGoToTermsAndConditions());
            GoToNew = new Command(async () => await OnReadyGoToNew());
            this.SexOptions = new string[] { "Femenino", "Masculino" };
            this.AgeOptions = new string[] { "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4" };
            OnLoad();
           
        }

        public UserModel Info { get; private set; }
        public Command GotoMainPage { get; set; }
        public Command GotoTermsAndConditions { get; set; }
        public Command GoToNew { get; set; }
        public bool Checked { get; set; }

        private bool _FirstTime = false;
        public bool FirstTime
        {
            get { return _FirstTime; }
            set { _FirstTime = value; OnPropertyChanged(); }
        }

        private bool _Existing = false;
        public bool Existing
        {
            get { return _Existing; } set {_Existing = value; OnPropertyChanged();}
        }
        private bool _New = false;

        public bool New
        {
            get { return _New; } set {_New = value; OnPropertyChanged();}
        }
        private int _Sexo = -1;
        public int Sexo
        {
            get { return _Sexo; }
            set
            {
                _Sexo = value;
                OnPropertyChanged();
            }
        }
        private int _Edad = -1;
        public int Edad
        {
            get { return _Edad; }
            set
            {
                _Edad = value;
                OnPropertyChanged();
            }
        }
        public string[] SexOptions { get; private set; }
        public string[] AgeOptions { get; private set; }



        /// <summary>
        ///En esta funcion se carga los datos iniciales de la app.
        /// </summary>
        /// <returns></returns>
        private async void OnLoad()
        {
            try
            {
                var a = DependencyService.Get<IFile>().Exist("Info");
                if (DependencyService.Get<IFile>().Exist("Info"))
                {
                    var jsonUser = DependencyService.Get<IFile>().LoadText("Info");
                    Info = JsonConvert.DeserializeObject<UserModel>(jsonUser);
                    UserExisting();

                }
                else
                {
                    UserFirstTime();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        private void UserFirstTime()
        {
            FirstTime = true;
            New = false;
            Existing = false;
        }
        private void UserNew()
        {
            FirstTime = false;
            New = true;
            Existing = false;
        }

        private void UserExisting()
        {
            FirstTime = false;
            Existing = true;
            New = false;
        }

        private async Task OnReadyGoToTermsAndConditions()
        {
            await App.Navigation.PushAsync(new Views.Registration.TermsAndConditions());
        }
        private async Task OnReadyGoToNew()
        {
            if(Checked==true)
            {
                UserNew();
            }
            else
            {
                await DialogExtensions.ShowDialog("ERROR", "Para continuar, Debes de aceptar los términos y Condiciones", "Aceptar");
            }
        }
        private async Task OnReady()
        {
            if (New)
            {

                var flag = true;
                if (string.IsNullOrEmpty(Info.Name))
                {
                    await DialogExtensions.ShowDialog("ERROR", "Para continuar, no olvides escribir tu nombre", "Aceptar");
                    flag = false;
                }
                if (Edad<0)
                {
                    await DialogExtensions.ShowDialog("ERROR", "Para continuar, no olvides seleccionar tu edad", "Aceptar");
                    flag = false;
                }
                if (Sexo<0)
                {
                    await DialogExtensions.ShowDialog("ERROR", "Para continuar, no olvides seleccionar el sexo", "Aceptar");
                    flag = false;
                }
                if (flag)
                {
                    Info.Age = AgeOptions[Edad];
                    Info.Sex = SexOptions[Sexo];
                    var json = JsonConvert.SerializeObject(Info);
                    DependencyService.Get<IFile>().SaveText("Info", json);
                    await App.Navigation.PushAsync(new Loading());
                }
            }
            else
            {
                await App.Navigation.PushAsync(new Loading());
            }
        }

    }
}