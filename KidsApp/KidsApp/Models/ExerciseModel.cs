using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models
{
    class ExerciseModel : ModelBase
    {
        private Guid _Id;
        public Guid Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private string _Type;
        public string Type { get { return _Type; } set { _Type = value; OnPropertyChanged(); } }
        private string _Exercise;
        public string Exercise { get { return _Exercise; } set { _Exercise = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get { return _Image; } set { _Image = value; OnPropertyChanged(); } }
    }
}
