using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models
{
    public class UserModel:ModelBase
    {
        private string _User;
        public string User { get { return _User; } set { _User = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged(); } }
        private string _Age;
        public string Age { get { return _Age; } set { _Age = value; OnPropertyChanged(); } }
        private string _Sex;
        public string Sex { get { return _Sex; } set { _Sex = value; OnPropertyChanged(); } }
        private string _Level;
        public string Level { get { return _Level; } set { _Level = value; OnPropertyChanged(); } }
        private decimal _Percentage;
        public decimal Percentage { get { return _Percentage; } set { _Percentage = value; OnPropertyChanged(); } }
        private int _Points;
        public int Points { get { return _Points; } set { _Points = value; OnPropertyChanged(); } }
    }
}

