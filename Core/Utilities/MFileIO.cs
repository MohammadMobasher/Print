using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{
    public class MFileIO
    {
        public MFileIO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void write(string fileName, string text)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath.MFileIO.GetDescription(), fileName);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllText(path, text, System.Text.Encoding.UTF8);
        }

        public static void append(string fileName, string text)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath.MFileIO.GetDescription());

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);



            string path2 = Path.Combine(path, fileName);
            //if (!File.Exists(path2))
            //    File.Create(path2);

            File.AppendAllText(path2, text, System.Text.Encoding.UTF8);
        }

    }
}
