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
    public class ExerciseViewModel : ViewModelBase
    {
        public ExerciseViewModel()
        {
            Info = new UserModel();
            GoToStart = new Command(async () => await OnReadyGoToStart());
            GoToNext = new Command(async () => await OnReadyGoToNext());
            OnLoad();
        }
        public UserModel Info { get; private set; }
        public Command GoToStart { get; set; }
        public Command GoToNext { get; set; }
        

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
                if (Info.Points <= 20)
                {
                    Level = "Principiante";
                }
                if (Info.Points > 20 && Info.Points <= 40)
                {
                    Level = "Intermedio";
                }
                if (Info.Points > 40)
                {
                    Level = "Avanzado";
                }

                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
                ExerciseLoad = rootobject.Exercises.Where(x=> x.Type==Level).ToArray();
            }
            ExerciseImage = ExerciseLoad[0].Image;
            ExerciseLevel = ExerciseLoad[0].Type;
            ExerciseName = ExerciseLoad[0].Exercise;
            ExerciseDescription = ExerciseLoad[0].Description;
            Total =ExerciseLoad.Count();
            Index = 1;

           


            if (Level == "Principiante") //Muestra el porcentaje
            {
                Info.Percentage = ((Info.Points * 100) / 20);
            }
            if (Level == "Intermedio")
            {
                Info.Percentage = ((Info.Points * 100) / 40);
            }
            if (Level == "Avanzado")
            {
                Info.Percentage = ((Info.Points * 100) / 60);
            }

        }

        private string _Level;
        public string Level
        {
            get { return _Level; }
            set { _Level = value; OnPropertyChanged(); }
        }

        private bool _CheckedOpt1;
        public bool CheckedOpt1
        {
            get { return _CheckedOpt1; }
            set
            {
                if (value)
                {
                    CheckedOpt2 = false;
                    CheckedOpt3 = false;
                }
                _CheckedOpt1 = value; OnPropertyChanged();
            }

        }
        private bool _CheckedOpt2;
        public bool CheckedOpt2
        {
            get { return _CheckedOpt2; }
            set
            {
                if (value)
                {
                    CheckedOpt1 = false;
                    CheckedOpt3 = false;
                }
                _CheckedOpt2 = value; OnPropertyChanged();
            }
        }
        private bool _CheckedOpt3;
        public bool CheckedOpt3
        {
            get { return _CheckedOpt3; }
            set { if(value)
                {
                 CheckedOpt1 = false;
                 CheckedOpt2 = false;
                }
                _CheckedOpt3 = value; OnPropertyChanged(); }
            
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

        private bool _Start = false;
        public bool Start
        {
            get { return _Start; }
            set { _Start = value; OnPropertyChanged(); }
        }

        public ExerciseModel[] ExerciseLoad { get; private set; }
        private async Task OnReadyGoToNext()
        {
            if(CheckedOpt1==true)
            {
                Info.Points = Info.Points + 2;
            }
            else if (CheckedOpt2==true)
            {
                Info.Points = Info.Points + 1;
            }
            else if(CheckedOpt3==true)
            {
                Info.Points = Info.Points + 0;
            }

            if (Index<Total)
            {
                Index= Index+1;
                ExerciseImage = ExerciseLoad[Index-1].Image;
                ExerciseLevel = ExerciseLoad[Index - 1].Type;
                ExerciseName = ExerciseLoad[Index - 1].Exercise;
                ExerciseDescription = ExerciseLoad[Index - 1].Description;
                CheckedOpt1 = false;
                CheckedOpt2 = false;
                CheckedOpt3 = false;
            }
            else
            {
                var json = JsonConvert.SerializeObject(Info);
                DependencyService.Get<IFile>().Delete("Info");
                DependencyService.Get<IFile>().SaveText("Info", json);
                await DialogExtensions.ShowDialog("Fin de los ejercicios", "Haz finalizado tu práctica de hoy. Felicidades!!!. Consulta tu puntuación la la sección -Progresos-","Aceptar");
                await App.Navigation.PushAsync(new MainPage());

            }

        }
        private async Task OnReadyGoToStart()
        {
            UserStart();
        }
        private void UserInstructions()
        {
            Instructions = true;
            Start = false;
        }
        private void UserStart()
        {
            Instructions = false;
            Start = true;
        }
    }
}
