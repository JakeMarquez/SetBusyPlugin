using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Diagnostics;

namespace SetBusyPlugin
{
    public class PluginListener
    {
        public bool Switch { get; set; }

        public bool Running { get; set; }

        public PluginListener(string setting)
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "SetBusyPlugin.exe";
                    eventLog.WriteEntry("SetBusyPlugin.exe is setting the listener for the StatusCheck event.", EventLogEntryType.Information, 105, 1);
                }
                Switch = setting.ToLower() == "on" ? true : false;
                //Set a listener for the StatusCheck event to be handled by the SetBusy method
                //This event should occur every 15 seconds.
                RoleEnvironment.StatusCheck += new EventHandler<RoleInstanceStatusCheckEventArgs>(SetBusy);
                Running = false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void SetBusy(object sender, RoleInstanceStatusCheckEventArgs e)
        {
           // set the instance as busy
           if (Switch)
           {
               e.SetBusy();
           }
        }
    }
}
