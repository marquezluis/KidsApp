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
    public class ExitViewModel
    {
        public ExitViewModel()
        {
            Info = new UserModel();
            OnLoad();
            onwait();
        }
        public UserModel Info { get; private set; }

        private async void OnLoad()
        {
            try
            {
                var a = DependencyService.Get<IFile>().Exist("Info");
                var jsonUser = DependencyService.Get<IFile>().LoadText("Info");
                Info = JsonConvert.DeserializeObject<UserModel>(jsonUser);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private async void onwait() //metodo
        {
            await Task.Delay(5000);
            throw new Exception(); //se sale el app
        }
    }
}