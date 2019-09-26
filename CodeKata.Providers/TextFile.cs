using System;
using System.IO;

namespace CodeKata.Providers
{
    public class TextFile
    {
        public static FileStream OpenFile(string fs)
        {
            FileStream file = new FileStream(fs, FileMode.Open, FileAccess.Read);
            return file;
        }

        public static FileStream WriteReport(string fs)
        {
            FileStream file = new FileStream(fs, FileMode.Create, FileAccess.Write);
            return file;
        }
    }
}
