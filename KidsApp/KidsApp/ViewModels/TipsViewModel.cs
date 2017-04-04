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
using System.Reflection;
using System.IO;

namespace KidsApp.ViewModels
{
    public class TipsViewModel : ViewModelBase
    {
        public TipsViewModel()
        {
            InfoTip = new TipsModel();
            GoToNext = new Command(async () => await OnReadyGoToNext());
            GoToDisplayTips = new Command(async () => await OnReadyGoToDisplayTips());
            GoToMainPage = new Command(async () => await OnReadyGoToMainPage());
            GoToYouTube = new Command(async () => await OnReadyGoToYouTube());
            var urlStore = Device.OnPlatform("https://www.youtube.com/watch?v=SNrAqVZ6BxE", "https://www.youtube.com/watch?v=SNrAqVZ6BxE", "https://www.youtube.com/watch?v=SNrAqVZ6BxE");
            onLoad();
        }
        public Command GoToYouTube { get; set; }
        public Command GoToNext { get; set; }
        public Command GoToDisplayTips { get; set; }
        public Command GoToMainPage { get; set; }
        public TipsModel InfoTip { get; private set; }
        public TipsModel[] TipsLoad { get; private set; }
        private async Task onLoad()
        {
            var jsonUser = DependencyService.Get<IFile>().LoadText("InfoTip");
            InfoTip = JsonConvert.DeserializeObject<TipsModel>(jsonUser);
            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("KidsApp.Tips.json");
            using (var reader = new System.IO.StreamReader(stream))
            {


                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject1>(json);
                TipsLoad = rootobject.Tips.ToArray();
            }


            TipsImage = TipsLoad[0].Image;
            TipsType = TipsLoad[0].Type;
            TipsName = TipsLoad[0].Name;
            TipsDescription = TipsLoad[0].Description;
            Total = TipsLoad.Count();
            Index = 1;

        }
        private async Task OnReadyGoToNext()
        {
            if (Index < Total)
            {
                Index = Index + 1;
                TipsImage = TipsLoad[Index - 1].Image;
                TipsType = TipsLoad[Index - 1].Type;
                TipsName = TipsLoad[Index - 1].Name;
                TipsDescription = TipsLoad[Index - 1].Description;
            }
            else
            {
                await DialogExtensions.ShowDialog("Fin de los tips", "Haz finalizado la lista de los tips disponibles!!!", "Aceptar");
                await App.Navigation.PushAsync(new MainPage());

            }

        }
        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { _Count = value; OnPropertyChanged(); }

        }
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; OnPropertyChanged(); }

        }

        private int _Total;
        public int Total
        {
            get { return _Total; }
            set { _Total = value; OnPropertyChanged(); }
        }

        private string _TipsImage;
        public string TipsImage
        {
            get { return _TipsImage; }
            set { _TipsImage = value; OnPropertyChanged(); }
        }
        private string _TipsType;
        public string TipsType
        {
            get { return _TipsType; }
            set { _TipsType = value; OnPropertyChanged(); }
        }
        private string _TipsName;
        public string TipsName
        {
            get { return _TipsName; }
            set { _TipsName = value; OnPropertyChanged(); }
        }
        private string _TipsDescription;
        public string TipsDescription
        {
            get { return _TipsDescription; }
            set { _TipsDescription = value; OnPropertyChanged(); }
        }
        private async Task OnReadyGoToYouTube()
        {
            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=SNrAqVZ6BxE"));
        }
        private async Task OnReadyGoToMainPage()
        {
            await App.Navigation.PushAsync(new MainPage());
        }
        private async Task OnReadyGoToDisplayTips()
        {
            await App.Navigation.PushAsync(new DisplayTips());
        }
    }
}


