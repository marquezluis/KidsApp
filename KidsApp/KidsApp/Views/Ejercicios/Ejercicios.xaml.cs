using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.Ejercicios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ejercicios : ContentPage
    {
        public Ejercicios()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ExerciseListViewModel();
        }
        
    }
}
