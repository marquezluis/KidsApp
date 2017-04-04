using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models
{
    public class TipsModel:ModelBase
    {
        private string _Type;
        public string Type { get { return _Type; } set { _Type = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get { return _Image; } set { _Image = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
    }
    public class Rootobject1
    {
        public TipsModel[] Tips { get; set; }
    }
}
