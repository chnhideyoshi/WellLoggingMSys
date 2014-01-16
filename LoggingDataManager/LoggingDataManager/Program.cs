using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace LoggingDataManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        #region GlobalControl
        static MainForm form1;
        public static void SetStatusMessage(string message)
        {
            if (form1 != null)
            {
                form1.ShowInStatusBar(message);
            }
        }
        public static Model.Project OpenedProject
        {
            get
            {
                if (form1 != null)
                {
                    return form1.CurrentProject;
                }
                else
                {
                    return null;
                }

            }
        }
        #endregion
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.InitConfiguration();
            form1 = new MainForm();
            try
            {
                Application.Run(form1);
            }
            catch
            {
                return;
            }
            //Application.Run(new DeviceManagement.NewDeviceForm());
            //Application.Run(new  CurveSettings.NewCurveForm());
        }
    }
}
