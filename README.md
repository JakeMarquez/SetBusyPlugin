# SetBusyPlugin
A plugin to set an Azure Cloud Service or Virtual Machine instance to busy. If you're having an issue with an instance, instead of rebooting
or deleting and redploying simply RDP into the instance - set it as busy and then fix it! Setting the instance as busy removes it from the 
load balancer.

# How to Use
Standalone
* Set up RDP for your virtual machine and remote in
* In this project, navigate to SetBusyPlugin\bin\Debug
* Drag the the two dll's mentioned in the dependencies section into the E/F drive approot
* Drag the SetBusyPlugin.exe and SetBusyPlugin.exe.config  into the E/F drive approot
* Open a command line
* Run the command `SetBusyPlugin.exe on` to set the role to busy. Changes will be reflected in Azure Portal within 3-4 minutes.
* Run the command `SetBusyPlugin.exe off` to set the role to running. Changes will be reflected in Azure Portal within 3-4 minutes.

Just .exe  
If you already have a copy of the two dll's mentioned in the dependencies section below within the bin folder of your project you can
simply drag the SetBusyPlugin.exe SetBusyPlugin.exe.config into the folder with them and run it from there! 

# Features
* Event Logs: If your experiencing issues with the plugin and would like to quickly view the logs you can in the Windows Event Viewer.
* Windows Application: the app can run in the background indefinitely, keeping your instance busy for days.

# Dependencies  
Microsoft.WindowsAzure.ServiceRuntime.dll 2.0.1196.19  
msshrtmi.dll 2.0.1196.19
