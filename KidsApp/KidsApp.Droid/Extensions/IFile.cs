using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Xamarin.Forms;
using KidsApp.Models;
using KidsApp.Models.Extensions;
[assembly: Dependency(typeof(KidsApp.Droid.Extensions.File))]
namespace KidsApp.Droid.Extensions

{
    public class File : IFile
    {
        public File()
        {
        }

        public bool Delete(string filename)
        {
            try
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                System.IO.File.Delete(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exist(string filename)
        {
            try
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                return System.IO.File.Exists(filePath);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] LoadBytes(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllBytes(filePath);
        }

        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
    }
}