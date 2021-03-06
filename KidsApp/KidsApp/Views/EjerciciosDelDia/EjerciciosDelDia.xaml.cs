﻿using KidsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Views.EjerciciosDelDia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EjerciciosDelDia : ContentPage
    {
        public EjerciciosDelDia()
        {
            InitializeComponent();
            this.BindingContext = new ExerciseViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
