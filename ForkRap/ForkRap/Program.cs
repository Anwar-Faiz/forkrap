using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkRap
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Error: You have not provided any parameter!");
                System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                return;
            }
            if (args[0] == "--help" || args[0] == "-h")
            {
                System.Console.WriteLine("ForkRap: [Help]");
                System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                System.Console.WriteLine("More details to be added ...");
            }



            // Stopping console to read result
            Console.ReadKey();
        }
    }
}
