using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class FileReader
    {
        public static string ReadAllText(string path)
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), path));
        }
    }
}
