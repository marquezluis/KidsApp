using KidsApp.Models;
using KidsApp.Models.Extensions;
using KidsApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KidsApp.ViewModels
{
    public class LoadingViewModel : ViewModelBase
    {
        public LoadingViewModel()
        {
            InfoTip = new TipsModel();
            onVerify();
            onLoad();
            onWait();
        }

        public TipsModel InfoTip { get; private set; }
        private async void onVerify() //metodo
        {
            try
            {
                var a = DependencyService.Get<IFile>().Exist("InfoTip");
                if (DependencyService.Get<IFile>().Exist("InfoTip"))
                {
                    var jsonUser = DependencyService.Get<IFile>().LoadText("InfoTip");
                    InfoTip = JsonConvert.DeserializeObject<TipsModel>(jsonUser);
                    onLoad();

                }
                else
                {
                    onLoad();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private async void onLoad() //metodo
        {
            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("KidsApp.Tips.json");
            using (var reader = new System.IO.StreamReader(stream))
            {


                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject1>(json);
                TipsLoad = rootobject.Tips.ToArray();
            }


            TipsImage = TipsLoad[InfoTip.Count].Image;
            TipsType = TipsLoad[InfoTip.Count].Type;
            TipsName = TipsLoad[InfoTip.Count].Name;
            TipsDescription = TipsLoad[InfoTip.Count].Description;
            Total = TipsLoad.Count();
            InfoTip.Count = InfoTip.Count + 1;

        }
        private async void onWait() //metodo
        {
            await Task.Delay(5000);


            if (InfoTip.Count == Total)
            {
                InfoTip.Count = 0;
            }
            var json = JsonConvert.SerializeObject(InfoTip);
            DependencyService.Get<IFile>().Delete("InfoTip");
            DependencyService.Get<IFile>().SaveText("InfoTip", json);
            App.Navigation.PushAsync(new MainPage());



        }



        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { _Count = value; OnPropertyChanged(); }

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
        public TipsModel[] TipsLoad { get; private set; }


    }
}
