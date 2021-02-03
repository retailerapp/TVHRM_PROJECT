namespace Sendmail_Birthday
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerSendmail = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerSendmail = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerSendmail
            // 
            this.serviceProcessInstallerSendmail.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerSendmail.Password = null;
            this.serviceProcessInstallerSendmail.Username = null;
            // 
            // serviceInstallerSendmail
            // 
            this.serviceInstallerSendmail.Description = "Auto_Sendmail_TV";
            this.serviceInstallerSendmail.DisplayName = "Auto_Sendmail_TV";
            this.serviceInstallerSendmail.ServiceName = "Auto_Sendmail_TV";
            this.serviceInstallerSendmail.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerSendmail,
            this.serviceInstallerSendmail});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerSendmail;
        public System.ServiceProcess.ServiceInstaller serviceInstallerSendmail;
    }
}