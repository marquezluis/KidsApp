using KidsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KidsApp.ViewModels
{
    public class HelpViewModel: ViewModelBase
    {
        public HelpViewModel()
        {
            GoToMainPage = new Command(async () => await OnReadyGoToMainPage());
        }
        public Command GoToMainPage { get; set; }

        private async Task OnReadyGoToMainPage()
        {
            await App.Navigation.PushAsync(new MainPage());
        }
    }

}
