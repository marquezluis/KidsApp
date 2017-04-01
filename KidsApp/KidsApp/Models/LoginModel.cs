using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models
{
    class LoginModel:ModelBase
    {
        private Guid _Id;
        public Guid Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private string _User;
        public string User { get { return _User; } set { _User = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }
    }
}
