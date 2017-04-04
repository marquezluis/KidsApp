using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Progresos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Progresos : ContentPage
    {
        public Progresos()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ProgresosViewModel();

        }
    }
}
