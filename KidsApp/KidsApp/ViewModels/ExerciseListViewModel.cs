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
using System.Reflection;
using System.IO;

namespace KidsApp.ViewModels
{
    public class ExerciseListViewModel : ViewModelBase
    {
        public ExerciseListViewModel()
        {
            GoToList = new Command(async () => await OnReadyGoToList());
            GoToNext = new Command(async () => await OnReadyGoToNext());
            GoToMainPage = new Command(async () => await OnReadyGoToMainPage());
            OnLoad();
        }
        public UserModel Info { get; private set; }
        public Command GoToList { get; set; }
        public Command GoToNext { get; set; }
        public Command GoToMainPage { get; set; }


        private async void OnLoad()
        {
            UserInstructions();

            var a = DependencyService.Get<IFile>().Exist("Info");
            var jsonUser = DependencyService.Get<IFile>().LoadText("Info");
            Info = JsonConvert.DeserializeObject<UserModel>(jsonUser);
            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("KidsApp.Exercises.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                Level = "Principiante";
                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
                ExerciseLoad = rootobject.Exercises.ToArray();
            }
            ExerciseImage = ExerciseLoad[0].Image;
            ExerciseLevel = ExerciseLoad[0].Type;
            ExerciseName = ExerciseLoad[0].Exercise;
            ExerciseDescription = ExerciseLoad[0].Description;
            Total = ExerciseLoad.Count();
            Index = 1;


        }

        private string _Level;
        public string Level
        {
            get { return _Level; }
            set { _Level = value; OnPropertyChanged(); }
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

        private string _ExerciseImage;
        public string ExerciseImage
        {
            get { return _ExerciseImage; }
            set { _ExerciseImage = value; OnPropertyChanged(); }
        }
        private string _ExerciseLevel;
        public string ExerciseLevel
        {
            get { return _ExerciseLevel; }
            set { _ExerciseLevel = value; OnPropertyChanged(); }
        }
        private string _ExerciseName;
        public string ExerciseName
        {
            get { return _ExerciseName; }
            set { _ExerciseName = value; OnPropertyChanged(); }
        }
        private string _ExerciseDescription;
        public string ExerciseDescription
        {
            get { return _ExerciseDescription; }
            set { _ExerciseDescription = value; OnPropertyChanged(); }
        }
        private bool _Instructions = false;
        public bool Instructions
        {
            get { return _Instructions; }
            set { _Instructions = value; OnPropertyChanged(); }
        }

        private bool _List = false;
        public bool List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        public ExerciseModel[] ExerciseLoad { get; private set; }
        private async Task OnReadyGoToNext()
        {
            if (Index < Total)
            {
                Index = Index + 1;
                ExerciseImage = ExerciseLoad[Index - 1].Image;
                ExerciseLevel = ExerciseLoad[Index - 1].Type;
                ExerciseName = ExerciseLoad[Index - 1].Exercise;
                ExerciseDescription = ExerciseLoad[Index - 1].Description;
            }
            else
            {
                await DialogExtensions.ShowDialog("Fin de los ejercicios", "Haz finalizado la lista de los ejercicios disponibles!!!", "Aceptar");
                await App.Navigation.PushAsync(new MainPage());

            }

        }
        private async Task OnReadyGoToList()
        {
            UserList();
        }
        private async Task OnReadyGoToMainPage()
        {
            await App.Navigation.PushAsync(new MainPage());
        }
        private void UserInstructions()
        {
            Instructions = true;
            List = false;
        }
        private void UserList()
        {
            Instructions = false;
            List = true;
        }
    }
}