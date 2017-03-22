using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Tips
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tips : ContentPage
    {
        public Tips()
        {
            InitializeComponent();
        }

        private async void Button_GoToDisplayTips(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Tips.DisplayTips());
        }
    }
}
