using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models
{
    class TipsModel:ModelBase
    {
        private Guid _Id;
        public Guid Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private string _Tip;
        public string Tip { get { return _Tip; } set { _Tip = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get { return _Image; } set { _Image = value; OnPropertyChanged(); } }
    }
}
