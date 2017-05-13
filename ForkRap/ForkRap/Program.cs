﻿using System;
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
            if (args.Length >3)
            {
                System.Console.WriteLine("Error: Do not get fancy with extra parameters. Please correct!");
                System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                return;
            }
            if (args.Length != 3)
            {
                System.Console.WriteLine("Error: Please provide all parameters in correct order.");
                System.Console.WriteLine("Syntax: forkwrap <url> <number_of_times> <destination_folder_path>");
                return;
            }

            // The main program logic starts
            String url;
            int times;
            String destination = "./output";

            try
            {
                url = args[0];
                times = int.Parse(args[1]);
                destination = args[2];
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception is thrown : " + e);
                return;
            }

            // Calling loopThrough class constructor and initializing parameters
            LoopThrough loopThrough = new LoopThrough(url, times, destination);




            // Stopping console to read result
            Console.ReadKey();
        }
    }
}