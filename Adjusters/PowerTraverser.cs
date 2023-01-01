using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;
namespace Adjusters
{
    internal class PowerTraverser
    {
        public static string[] GetLines (string path)
        {
            string [] lines = File.ReadAllLines (path);
            return lines;
        }

        public static bool SetLines(string path, string [] lines)
        {
            StringBuilder stringBuilder = new StringBuilder ();

            foreach (string line in lines) 
            {
                stringBuilder.Append(line);
                stringBuilder.Append("\r\n"); // add CLRF
            }

            File.WriteAllText(path, stringBuilder.ToString());

            return true;
        }






    }


}
