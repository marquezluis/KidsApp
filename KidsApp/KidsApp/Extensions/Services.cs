using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Extensions
{
    public class DialogExtensions
    {

        public static Task<bool> ShowDialog(string title, string message, string accept = "Ok", string cancel = "Cancel")
        {
            var dialogResult = App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            return Task.Run(() => dialogResult);

        }
        public static Task ShowDialog(string title, string message, string accept = "Ok")
        {

            var dialogResult = App.Current.MainPage.DisplayAlert(title, message, accept);
            return Task.Run(() => dialogResult);

        }
    }
}