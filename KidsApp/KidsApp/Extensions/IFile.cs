using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Models.Extensions
{
    public interface IFile
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        Boolean Exist(string filename);
        Boolean Delete(string filename);
        byte[] LoadBytes(string filename);
    }
}
