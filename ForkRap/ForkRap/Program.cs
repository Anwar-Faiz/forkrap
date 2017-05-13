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
                return;
            }
            if (args.Length >3)
            {
                if(args[3] == "--noWait" || args[3] == "--nowait" || args[3] == "--NOWAIT" || args[3] == "--NoWait")
                {
                    LoopThrough.noWaitMode = true;
                }
                else
                {
                    System.Console.WriteLine("Error: Do not get fancy with extra parameters. Please correct!");
                    System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                    return;
                }
            }

            // The Main program logic starts
            String api;
            int times;
            String destination;

            try
            {
                api = args[0];
                times = int.Parse(args[1]);
                destination = args[2];
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error: Input Parameters are invalid!");
                System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                System.Console.WriteLine("Exception Stacktrace :\n" + e);
                return;
            }

            // Checking destination folder or creating it if not present using SafeFileIO Class
            SafeFileIO.IfPathNotExistsCreateIt(destination);
            
            // minimum times should be 1
            if (times <= 0) { times = 1; }

            // validating Uri of Api send
            Uri uri = null;
            bool result = Uri.TryCreate(api, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                System.Console.WriteLine("Error: URI of Api send is incorrect. Please check!\n");
                System.Console.WriteLine("URI Syntax: http://<api or webs service address> ?param1=value1&param2=value2...");
                return;
            }

            // Calling loopThrough class constructor and initializing parameters with Uri, times and destination.
            LoopThrough loopThrough = new LoopThrough(uri.ToString(), times, destination);
            loopThrough.getRap();

            // Detecting end of all threads execution
            if(true)
            {
                System.Console.WriteLine("\n\n[Multithreading Summary]");
                System.Console.WriteLine("[Threads opened : " + LoopThrough.threadsOpened.ToString() + "]");
                System.Console.WriteLine("[Threads closed : " + LoopThrough.threadsClosed.ToString() + "]");
                System.Console.WriteLine("\n<-- forkrap: Mission accompalished! -->");
            }
        }
    }
}
