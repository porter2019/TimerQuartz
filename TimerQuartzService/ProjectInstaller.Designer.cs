namespace TimerQuartzService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ServiceProcess.ServiceInstaller ServiceInsraller1;
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            ServiceInsraller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceInsraller1
            // 
            ServiceInsraller1.DelayedAutoStart = true;
            ServiceInsraller1.Description = "定时执行某些任务";
            ServiceInsraller1.DisplayName = "TimerQuartzService";
            ServiceInsraller1.ServiceName = "TimerQuartzService";
            ServiceInsraller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.TimerQuartzService_AfterInstall);
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            ServiceInsraller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}