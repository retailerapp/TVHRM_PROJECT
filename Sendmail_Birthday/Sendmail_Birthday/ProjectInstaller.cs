using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Sendmail_Birthday
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        //private readonly ServiceProcessInstaller processInstaller;
        //private readonly System.ServiceProcess.ServiceInstaller serviceInstaller;
        public ProjectInstaller()
        {
            InitializeComponent();
            //serviceProcessInstallerSendmail = new ServiceProcessInstaller();
            //serviceInstallerSendmail = new System.ServiceProcess.ServiceInstaller();

            //// Service will run under system account
            //serviceProcessInstallerSendmail.Account = ServiceAccount.LocalSystem;

            ////// Service will have Start Type of Manual
            //serviceInstallerSendmail.StartType = ServiceStartMode.Automatic;

            //serviceInstallerSendmail.ServiceName = "Windows Automatic Start Service";

            //Installers.Add(serviceInstallerSendmail);
            //Installers.Add(serviceProcessInstallerSendmail);
            //serviceInstallerSendmail.AfterInstall += ServiceInstaller_AfterInstall;  
        }

        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController("Windows Automatic Start Service");
            sc.Start();

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C sc start " + this.serviceInstallerSendmail.ServiceName;

            //Process process = new Process();
            //process.StartInfo = startInfo;
            //process.Start();
        }
    }
}
