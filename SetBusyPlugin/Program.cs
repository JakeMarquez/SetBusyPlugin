using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace SetBusyPlugin
{
    class Program
    {
        //Manages Restart Event
        static ManualResetEvent App = new ManualResetEvent(false);

        //GUID of the EXE
        const string GUID = "0ca34421-3bf3-48be-b5c8-81fcb1ad69ee";

        
        static void Main(string[] args)
        {
            Log(1);
            //All running processes with the same name
            IEnumerable<Process> processes = Process.GetProcessesByName("SetBusyPlugin").Where(x=>x.MainModule.FileVersionInfo.FileDescription==GUID);
            if (args.Length == 0)
            {
                Log(2);
                throw new ArgumentException("You must pass an argument (either 'on' or 'off')");
            }
            //Stop the plugin if they press ctr+c
            //Console.CancelKeyPress += (sender, eArgs) => {
            //    App.Set();
            //    eArgs.Cancel = true;
            //};
            if (args[0].ToLower() == "off")
            {
                Log(3);
                foreach (var process in processes)
                {
                    process.Kill();
                }
                return;
            }
            else   
            {
                Log(4);
                if (processes.Count() > 1)
                {
                    Log(5);
                    return;
                }
                else
                { 
                    // Set up the listener
                    PluginListener SetBusyPlugin = new PluginListener(args[0]);
                    //return "Setting Role Instance to Busy";
                }
            }
            // Keeps the app running until it is terminated or if ctr+c is pressed in the original command line window
            App.WaitOne();
        }

        static void Log(int id)
        {
            switch (id)
            {
                case 1:
                    EventLogger("SetBusyPlugin.exe is initializing", 101, 4);
                    break;
                case 2:
                    EventLogger("SetBusyPlugin.exe is exiting: You must pass an argument (either 'on' or 'off').", 102, 1);
                    break;
                case 3:
                    EventLogger("SetBusyPlugin.exe is returning role to running state.", 103, 4);
                    break;
                case 4:
                    EventLogger("SetBusyPlugin.exe is setting role to busy state.", 104, 4);
                    break;
                case 5:
                    EventLogger("SetBusyPlugin.exe is exiting: An instance of SetBusyPlugin.exe is already running.", 105, 1);
                    break;
            }
        }

        static void EventLogger(string message, int id, int type)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "SetBusyPlugin.exe";
                eventLog.WriteEntry(message, (EventLogEntryType)type, id, 1);
            }
        }
    }
}
