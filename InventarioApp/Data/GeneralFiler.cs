using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioApp.Data
{
    class GeneralFiler
    {
        static FileStream fs;
        static string PATH = Application.StartupPath+@"\\product1.dat";
        public static FileStream getFS()
        {
            if (!File.Exists(PATH))
            {
                fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Seek(0, SeekOrigin.Begin);
                BinaryWriter w = new BinaryWriter(fs);
                w.Write(0);
                w.Write(0);
            }
            else
            {
                fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Seek(0, SeekOrigin.Begin);
            }
            return fs;
        }
        public static void resetFile()
        {
            File.Delete(PATH);
        }
    }
}
