using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp
{
    public class LoadResourceText
    {
        public LoadResourceText()
        {


            #region How to load a text file embedded resource
            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("KidsApp.PCLTextResource.txt");

            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            #endregion
        }
    }
}
