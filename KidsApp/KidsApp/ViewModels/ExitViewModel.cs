using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.ViewModels
{
    public class ExitViewModel
    {
        public ExitViewModel()
        {
            onwait();
        }

        private async void onwait() //metodo
        {
            await Task.Delay(5000);
            throw new Exception(); //se sale el app
        }
    }
}