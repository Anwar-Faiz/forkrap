using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkRap
{
    class SafeFileIO
    {
        public static void IfPathNotExistsCreateIt(string path)
        {
            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch( Exception e)
                {
                    System.Console.WriteLine("Error Creating directory!");
                    System.Console.WriteLine("Error Stacktrace: \n" + e.ToString());
                }
            }
                
        }
    }
}
