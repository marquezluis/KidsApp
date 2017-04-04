using KidsApp.ViewModels;
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
    public partial class DisplayTips : ContentPage
    {
        public DisplayTips()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new TipsViewModel();
        }
    }
}
