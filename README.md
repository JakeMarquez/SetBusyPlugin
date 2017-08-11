# SetBusyPlugin
A plugin to set an Azure Cloud Service or Virtual Machine instance to busy. If you're having an issue with an instance, instead of rebooting
or deleting and redploying simply RDP into the instance - set it as busy and then fix it! Setting the instance as busy removes it from the 
load balancer.

# How to Use
Standalone
* Set up RDP for your virtual machine and remote in
* In this project, navigate to SetBusyPlugin\bin\Debug
* Drag the the two dll's mentioned in the dependencies section into your project folder
* Drag the SetBusyPlugin.exe and SetBusyPlugin.exe.config  into the same folder
* Upload/Update your project in the cloud
* Open a command line in the directory where SetBusyPlugin is via RDP or CommandLine interface
* Run the command `SetBusyPlugin.exe on` to set the role to busy. Changes will be reflected in Azure Portal within 3-4 minutes.
* Run the command `SetBusyPlugin.exe off` to set the role to running. Changes will be reflected in Azure Portal within 3-4 minutes.

Azure Tip: If you have a Cloud Service, you can create RDP settings for your vms in the Azure blade, and RDP into the instance to set it busy. If you have a App Service you cant RDP because you dont own the VM your site is run on, but you can access its files through KUDO if you go to App Service-> (left hand side) Advanced Tools -> Go-> (at top) Debug Console-> CMD

# Features
* Event Logs: If your experiencing issues with the plugin and would like to quickly view the logs you can in the Windows Event Viewer.
* Windows Application: the app can run in the background indefinitely, keeping your instance busy for days.

# Dependencies  
Microsoft.WindowsAzure.ServiceRuntime.dll 2.0.1196.19  
msshrtmi.dll 2.0.1196.19
