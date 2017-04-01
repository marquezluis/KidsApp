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
    public class TipsViewModel
    {
        public TipsViewModel()
        {
            GoToYouTube = new Command(async () => await OnReadyGoToYouTube());
            var urlStore = Device.OnPlatform("https://www.youtube.com/watch?v=SNrAqVZ6BxE", "https://www.youtube.com/watch?v=SNrAqVZ6BxE", "https://www.youtube.com/watch?v=SNrAqVZ6BxE");

        }
        public Command GoToYouTube { get; set; }

        


        private async Task OnReadyGoToYouTube()
        {
            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=SNrAqVZ6BxE"));
        }
        
    }
}


