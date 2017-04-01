using KidsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.ViewModels
{
    public class LoadingViewModel
    {
        public LoadingViewModel()
        {
            onwait();
        }

        private async void onwait() //metodo
        {
            await Task.Delay(5000);
            App.Navigation.PushAsync(new MainPage());
        }
    }
}
